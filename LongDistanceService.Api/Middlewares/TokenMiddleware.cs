using LongDistanceService.Api.Services.Abstract;

namespace LongDistanceService.Api.Middlewares;

public class TokenMiddleware(RequestDelegate next, ITokenManager tokenManager)
{
    public async Task Invoke(HttpContext context)
    {
        var accessToken = tokenManager.Token;
        if (accessToken != null)
        {
            context.Request.Headers.Authorization = "Bearer " + accessToken;
        }
        
        await next.Invoke(context);
    }
}