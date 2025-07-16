using LongDistanceService.Api.Models.Responses;
using Newtonsoft.Json;

namespace LongDistanceService.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
        }
    }

    private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
    {
        if (context.Response.HasStarted) return Task.FromResult(context);
        
        var result =
            JsonConvert.SerializeObject(new ApiResponse(StatusCodes.Status500InternalServerError, null,
                exception.Message));
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status200OK;
        return context.Response.WriteAsync(result);
    }
}