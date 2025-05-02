using System.Net;
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
        context.Response.ContentType = "application/json";  
        int statusCode = (int)HttpStatusCode.InternalServerError;  
        var result = JsonConvert.SerializeObject(new ApiResponse(statusCode, false, null, exception.Message));  
        context.Response.ContentType = "application/json";  
        context.Response.StatusCode = statusCode;  
        return context.Response.WriteAsync(result);
    } 
}