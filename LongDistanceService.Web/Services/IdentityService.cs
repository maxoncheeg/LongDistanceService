using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Models;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Web.Routes;
using LongDistanceService.Web.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;

namespace LongDistanceService.Web.Services;

public class IdentityService(
    IHttpContextAccessor contextAccessor,
    IMediator mediator,
    IAccessTokenService tokenService,
    IPasswordHasher passwordHasher,
    AuthenticationStateProvider provider) : IIdentityService
{
    public async Task<int?> SignInAsync(string login, string password)
    {
        var response = await mediator.Send(new GetUserByLoginRequest() { Login = login });

        if (response == null)
            return null;

        if (!passwordHasher.VerifyHashedPassword(response.PasswordHash, password))
            return null;

        var user = new User() { Id = response.Id, Login = response.Login };
        var tokenData = tokenService.GenerateToken(new User() { Id = response.Id, Login = response.Login });

        var identity = new ClaimsIdentity(new List<Claim>()
                { new Claim(ClaimTypes.Authentication, tokenData.AccessToken) },
            CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties();

        properties.StoreTokens(new List<AuthenticationToken>()
        {
            new AuthenticationToken()
            {
                Name = JwtBearerDefaults.AuthenticationScheme,
                Value = tokenData.AccessToken
            }
        });

        if (contextAccessor.HttpContext == null)
            return null;

        contextAccessor.HttpContext.User = principal;
        
        var refreshToken = tokenService.GenerateRefreshToken(new User() { Id = user.Id, Login = login });
        
        await contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            contextAccessor.HttpContext.User,
            properties);

        return user.Id;
    }

    public async Task<bool> RefreshSignInAsync(string refreshToken, string expiredToken)
    {
        var newToken = await tokenService.RefreshTokenAsync(refreshToken, expiredToken);

        if (newToken == null)
            return false;

        var identity = new ClaimsIdentity(new List<Claim>()
                { new Claim(ClaimTypes.Authentication, newToken) },
            CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties();

        properties.StoreTokens(new List<AuthenticationToken>()
        {
            new AuthenticationToken()
            {
                Name = JwtBearerDefaults.AuthenticationScheme,
                Value = newToken
            }
        });

        if (contextAccessor.HttpContext == null)
            return false;

        
        contextAccessor.HttpContext.User = principal;
        await contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            contextAccessor.HttpContext.User,
            properties);

        return true;
    }

    public void AddRefreshToken(int id, string login)
    {
        if (contextAccessor.HttpContext == null || contextAccessor.HttpContext.User.Identity is not
            {
                IsAuthenticated: true
            })
            return;

        var refreshToken = tokenService.GenerateRefreshToken(new User() { Id = id, Login = login });

        contextAccessor.HttpContext.Response.Cookies.Append("refresh_token", refreshToken, new CookieOptions()
        {
            HttpOnly = true, Path = ServiceRoutes.Identity.RefreshToken
        });
    }

    public async Task<string?> ExtractTokenAsync()
    {
        var auth = await provider.GetAuthenticationStateAsync();

        var claim = auth.User.FindFirst(ClaimTypes.Authentication);
        return claim?.Value ?? null;
    }
    
    public string? ExtractRefreshToken()
    {
        if (contextAccessor.HttpContext == null || contextAccessor.HttpContext.User.Identity == null ||
            !contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            return null;

        contextAccessor.HttpContext.Request.Cookies.TryGetValue("refresh_token", out var token);
        return token;
    }

    public async Task<bool> SignOutAsync()
    {
        if (contextAccessor.HttpContext == null || contextAccessor.HttpContext.User.Identity == null ||
            !contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            return false;

        contextAccessor.HttpContext.Response.Cookies.Delete("refresh_token");
        await contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return true;
    }
}