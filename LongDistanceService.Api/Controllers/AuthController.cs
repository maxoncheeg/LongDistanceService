using System.Security.Claims;
using System.Text;
using LongDistanceService.Api.Controllers.Abstract;
using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Api.Models.Auth;
using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Users;
using LongDistanceService.Domain.Services.Entities.Abstract;
using LongDistanceService.Domain.Services.Identity.Abstract;
using LongDistanceService.Domain.Services.Utils.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LongDistanceService.Api.Controllers;

public class AuthController(
    IIdentityService identityService,
    IAccessTokenService accessTokenService,
    ITokenManager tokenManager,
    IUserService userService,
    ISecurityService securityService
) : AbstractController
{
    private readonly Func<string, string> _getRedirectHtml = url => $@"
<!DOCTYPE html>
<html lang=""ru"">
<head>
    <meta charset=""UTF-8"">
    <title>Перенаправление</title>
    <meta http-equiv=""refresh"" content=""0;url={url}"">
    <style>
        body {{
            font-family: Arial, sans-serif;
            text-align: center;
            margin-top: 100px;
        }}
        button {{
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
        }}
    </style>
</head>
<body>
<h1>Вы будете перенаправлены...</h1>
<p>Если не перенаправило автоматически, нажмите на кнопку ниже.</p>
<button onclick=""window.location.href='{url}'"">Перейти</button>
</body>
</html>";


    [HttpPost(ServiceRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] UserModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Login) || string.IsNullOrWhiteSpace(model.Password))
            return BaseResponse(StatusCodes.Status400BadRequest, null, "Invalid login or password");

        var authResult = await identityService.LoginAsync(model.Login, model.Password);

        if (!authResult.UserExists)
            return BaseResponse(StatusCodes.Status404NotFound, null, "No such user exists");
        if (!authResult.IsAuthenticated)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Invalid password");
        if (authResult.User == null)
            return BaseResponse(StatusCodes.Status404NotFound, null, "User not found");

        var token = accessTokenService.GenerateToken(authResult.User);
        var refreshToken = accessTokenService.GenerateRefreshToken(authResult.User);

        tokenManager.Token = token.AccessToken;
        tokenManager.RefreshToken = refreshToken;

        return BaseResponse(StatusCodes.Status200OK, authResult.User);
    }

    [HttpPost(ServiceRoutes.Auth.Logout)]
    public IActionResult Logout()
    {
        tokenManager.Token = null;
        tokenManager.RefreshToken = null;

        return BaseResponse(StatusCodes.Status200OK);
    }

    [HttpPut(ServiceRoutes.Auth.Register)]
    public async Task<IActionResult> Register([FromBody] UserModel model)
    {
        // todo: check mail

        var user = await userService.CreateUserAsync(model.Login, model.Password, [Roles.Client]);

        if (user is null)
        {
            return BaseResponse(StatusCodes.Status400BadRequest, null, "Invalid login or password");
        }

        var token = accessTokenService.GenerateToken(user);
        var refreshToken = accessTokenService.GenerateRefreshToken(user);

        tokenManager.Token = token.AccessToken;
        tokenManager.RefreshToken = refreshToken;

        return BaseResponse(StatusCodes.Status201Created, user);
    }

    [Authorize]
    [HttpPost(ServiceRoutes.Auth.LoginByToken)]
    public async Task<IActionResult> LoginByToken()
    {
        var token = tokenManager.Token;

        if (token == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Invalid token");

        var result = await identityService.LoginAsync(token);

        if (result.User == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Invalid token");

        return BaseResponse(StatusCodes.Status200OK, result.User);
    }

    [HttpPost(ServiceRoutes.Auth.RefreshToken)]
    public async Task<IActionResult> RefreshToken()
    {
        var token = tokenManager.Token;
        var refreshToken = tokenManager.RefreshToken;

        if (token == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Invalid token");
        if (refreshToken == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Invalid refresh token");

        var newToken = await accessTokenService.RefreshTokenAsync(refreshToken, token);
        if (newToken == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Error during refresh token");

        var result = await identityService.LoginAsync(newToken);
        if (result.User == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Error during refresh token");

        tokenManager.Token = newToken;

        return BaseResponse(StatusCodes.Status200OK, result.User);
    }


    [HttpGet(ServiceRoutes.Auth.OAuth.Provider)]
    public async Task<IActionResult> AuthByProvider(string provider, string returnUrl = "/api", bool register = false)
    {
        string userId = string.Empty;

        if (tokenManager.Token != null)
        {
            var data = await accessTokenService.GetUserDataFromTokenAsync(tokenManager.Token);
            userId = data?.Id.ToString() ?? string.Empty;
        }

        var redirectUrl = Url.Action(register ? nameof(RegisterProviderForUser) : nameof(GetAuthDataFromProvider),
            new { Provider = provider, ReturnUrl = returnUrl });
        var properties = new AuthenticationProperties
        {
            RedirectUri = redirectUrl,
            Items =
            {
                ["userId"] = userId
            }
        };

        return Challenge(properties, provider);
    }

    [HttpGet(ServiceRoutes.Auth.OAuth.Authorize)]
    public async Task<IActionResult> GetAuthDataFromProvider(string provider, string returnUrl = "/")
    {
        AuthenticateResult externalAuthResult = await HttpContext.AuthenticateAsync(provider);

        ClaimsPrincipal? principal = externalAuthResult.Principal;

        if (principal == null)
            return BaseResponse(StatusCodes.Status404NotFound, null, "Invalid provider authentication");

        var providerIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
        if (providerIdClaim == null)
            return BaseResponse(StatusCodes.Status404NotFound, null, "Cannot find data by provider");

        string providerId = providerIdClaim.Value;

        var authResult = await identityService.LoginByProviderAsync(provider, providerId);

        if (!authResult.UserExists)
            return BaseResponse(StatusCodes.Status404NotFound, null, "No such user exists");
        if (!authResult.IsAuthenticated)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Invalid password");
        if (authResult.User == null)
            return BaseResponse(StatusCodes.Status404NotFound, null, "User not found");

        tokenManager.Token = accessTokenService.GenerateToken(authResult.User).AccessToken;
        tokenManager.RefreshToken = accessTokenService.GenerateRefreshToken(authResult.User);

        return Content(_getRedirectHtml(returnUrl), "text/html", Encoding.UTF8);
    }

    [HttpGet(ServiceRoutes.Auth.OAuth.Register)]
    public async Task<IActionResult> RegisterProviderForUser(string provider, string returnUrl = "/")
    {
        AuthenticateResult externalAuthResult = await HttpContext.AuthenticateAsync(provider);

        ClaimsPrincipal? principal = externalAuthResult.Principal;
        var userIdItem = externalAuthResult.Properties?.Items["userId"] ?? string.Empty;

        if (principal == null)
            return BaseResponse(StatusCodes.Status404NotFound, null, "Invalid provider authentication");

        var providerIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
        if (providerIdClaim == null)
            return BaseResponse(StatusCodes.Status404NotFound, null, "Cannot find data by provider");

        string providerId = providerIdClaim.Value;

        if (string.IsNullOrEmpty(userIdItem) || !int.TryParse(userIdItem, out var userId))
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Cannot register provider without user");

        var result = await identityService.AddLoginProviderAsync(userId, provider, providerId);

        if (result)
        {
            var authResult = await identityService.LoginByProviderAsync(provider, providerId);

            if (!authResult.UserExists)
                return BaseResponse(StatusCodes.Status404NotFound, null, "No such user exists");
            if (!authResult.IsAuthenticated)
                return BaseResponse(StatusCodes.Status401Unauthorized, null, "");
            if (authResult.User == null)
                return BaseResponse(StatusCodes.Status404NotFound, null, "User not found");

            tokenManager.Token = accessTokenService.GenerateToken(authResult.User).AccessToken;
            tokenManager.RefreshToken = accessTokenService.GenerateRefreshToken(authResult.User);
        }

        return Content(_getRedirectHtml(returnUrl), "text/html", Encoding.UTF8);
    }
}