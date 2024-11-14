using System.Security.Claims;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Models;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Web.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LongDistanceService.Web.Services;

public class AuthorizationService(
    IHttpContextAccessor contextAccessor,
    IMediator mediator,
    IAccessTokenService tokenService,
    IPasswordHasher passwordHasher) : IAuthorizationService
{
    public async Task<bool> SignInAsync(string login, string password)
    {
        var response = await mediator.Send(new GetUserByLoginRequest() { Login = login });

        if (response == null)
            return false;

        if (!passwordHasher.VerifyHashedPassword(response.PasswordHash, password))
            return false;

        var tokenData = tokenService.GenerateToken(new User() { Id = response.Id, Login = response.Login });
        var identity = new ClaimsIdentity(new List<Claim>()
            { new Claim(ClaimTypes.Authentication, "Bearer " + tokenData.AccessToken) }, JwtBearerDefaults.AuthenticationScheme);
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
            return false;

        contextAccessor.HttpContext.User = principal;
        await contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            contextAccessor.HttpContext.User,
            properties);
        return true;
    }

    public async Task<bool> SignOutAsync()
    {
        if (contextAccessor.HttpContext == null || contextAccessor.HttpContext.User.Identity == null ||
            !contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            return false;

        await contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return true;
    }
}