using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Domain.Services.Identity.Abstract;

namespace LongDistanceService.Api.Services;

public class TokenManager(IHttpContextAccessor contextAccessor) : ITokenManager
{
    public string? RefreshToken
    {
        get => ExtractToken("lds_refresh_token");
        set => SetToken(value, "lds_refresh_token", ServiceRoutes.Auth.RefreshToken);
    }

    public string? Token
    {
        get => ExtractToken("lds_access_token");
        set => SetToken(value, "lds_access_token", ServiceRoutes.Api);
    }

    private string? ExtractToken(string tokenName)
    {
        var context = contextAccessor.HttpContext;
        if (context == null) return null;

        return context.Request.Cookies.TryGetValue(tokenName, out var token) ? token : null;
    }

    private void SetToken(string? token, string tokenName, string path)
    {
        var context = contextAccessor.HttpContext;
        if (context == null) return;

        if (token == null)
        {
            context.Response.Cookies.Append(tokenName, "", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(-1),
                HttpOnly = true,
                Path = path,
                SameSite = SameSiteMode.Strict
            });
        }
        else
        {
            context.Response.Cookies.Append(tokenName, token, new CookieOptions
            {
                HttpOnly = true,
                Path = path,
                SameSite = SameSiteMode.Strict
            });
        }
    }
}