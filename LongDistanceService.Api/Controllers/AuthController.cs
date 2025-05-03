using LongDistanceService.Api.Controllers.Abstract;
using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Api.Models.Auth;
using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Domain.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace LongDistanceService.Api.Controllers;

public class AuthController(
    IIdentityService identityService, 
    IAccessTokenService accessTokenService, 
    ITokenManager tokenManager,
    IPasswordHasher passwordHasher
    ) : AbstractController
{
    [HttpPost(ServiceRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody]LoginModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Login) || string.IsNullOrWhiteSpace(model.Password))
            return BaseResponse(StatusCodes.Status400BadRequest, false, null, "Invalid login or password");
        
        var authResult = await identityService.LoginAsync(model.Login, model.Password);
        
        if(!authResult.UserExists)
            return BaseResponse(StatusCodes.Status404NotFound, false, null, "No such user exists");
        if(!authResult.IsAuthenticated)
            return BaseResponse(StatusCodes.Status401Unauthorized, false, null, "Invalid password");
        if(authResult.User == null)
            return BaseResponse(StatusCodes.Status404NotFound, false, null, "User not found");
        
        var token = accessTokenService.GenerateToken(authResult.User);
        var refreshToken = accessTokenService.GenerateRefreshToken(authResult.User);
        
        tokenManager.Token = token.AccessToken;
        tokenManager.RefreshToken = refreshToken;
        
        return BaseResponse(StatusCodes.Status200OK, false);
    }
    
    [Authorize]
    [HttpPost(ServiceRoutes.Auth.Logout)]
    public IActionResult Logout()
    {
        HttpContext.Response.Headers.Authorization = new();
        tokenManager.Token = null;
        tokenManager.RefreshToken = null;
        
        return BaseResponse(StatusCodes.Status200OK, false);
    }

    [Authorize]
    [HttpGet("api/auth/pass")]
    public IActionResult GetPass([FromQuery]string password)
    {
        Console.WriteLine(tokenManager.RefreshToken);
        return BaseResponse(StatusCodes.Status200OK, true, passwordHasher.Hash(password));
    }
    
    [Authorize]
    [HttpGet(ServiceRoutes.Auth.RefreshToken)]
    public IActionResult GetPass()
    {
        Console.WriteLine(tokenManager.RefreshToken);
        return BaseResponse(StatusCodes.Status200OK, true);
    }
}