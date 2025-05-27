using System.Security.Claims;
using LongDistanceService.Api.Controllers.Abstract;
using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Api.Models.Auth;
using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Domain.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LongDistanceService.Api.Controllers;


public class AuthController(
    IIdentityService identityService,
    IAccessTokenService accessTokenService,
    ITokenManager tokenManager,
    IPasswordHasher passwordHasher
) : AbstractController
{
    EventHandler<string> onTokenValidated;
    
    [HttpPost(ServiceRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
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

    [Authorize(Policy = "AdminOnly")]
    [HttpGet("api/auth/pass")]
    public IActionResult GetPass([FromQuery] string password)
    {
        return BaseResponse(StatusCodes.Status200OK, passwordHasher.Hash(password));
    }
    
    [Authorize]
    [HttpPost(ServiceRoutes.Auth.LoginByToken)]
    public async Task<IActionResult> LoginByToken()
    {
        var token = tokenManager.Token;

        if (token == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "Invalid token");

        var result = await identityService.LoginAsync(token);
        
        if(result.User == null)
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
    public IActionResult AuthByProvider(string provider, string returnUrl = "/api")
    {
        var redirectUrl = Url.Action(nameof(GetAuthDataFromProvider), new { Provider=provider, ReturnUrl = returnUrl });
        var properties = new AuthenticationProperties()
        {
            RedirectUri = redirectUrl
        };
        
        return Challenge(properties, provider);
    }

    [HttpGet(ServiceRoutes.Auth.OAuth.Authorize)]
    public async Task<IActionResult> GetAuthDataFromProvider(string provider, string redirectUri = "/")
    {
        AuthenticateResult externalAuthResult = await HttpContext.AuthenticateAsync(provider);

        ClaimsPrincipal? principal = externalAuthResult.Principal;

        if (principal == null) return Content("nothing");

        var providerIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
        
        if(providerIdClaim == null) return Content("nothing");

        string providerId = providerIdClaim.Value;
        
        
        // if (!principal.TryGetClaimValue<string>(ClaimTypes.NameIdentifier, out var oAuthId))
        //     return BadRequest("External authentication error. Unknown userid");
        //
        // foreach (Claim claim in principal.Claims)
        // {
        //     Console.WriteLine(claim.Type + " |||:||| " + claim.Value);
        // }
        //
        // var token = accessFactory.GenerateTokenForExternalUser(oAuthId, "haha lol useless parameter");
        var token = providerId;
        return base.Content($"<h1>Bearer {token}</h1><button onclick='navigator.clipboard.writeText(\"{token}\")'>copy</button>", "text/html");
    }
}