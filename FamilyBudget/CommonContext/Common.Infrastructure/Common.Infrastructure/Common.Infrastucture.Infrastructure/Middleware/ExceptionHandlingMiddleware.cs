using System.Net.Mime;
using System.Text.Json;
using Common.Infrastucture.Infrastructure.Exception;
using Microsoft.AspNetCore.Http;

namespace Common.Infrastucture.Infrastructure.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            context.Response.ContentType = MediaTypeNames.Application.Json;
            
            if (e is UserReadableException)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync( JsonSerializer.Serialize(new
                {
                    traceId = context.TraceIdentifier, 
                    message = e.Message
                }));
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync( JsonSerializer.Serialize(new
                {
                    traceId = context.TraceIdentifier, 
                    message = "Произошла непредвиденная ошибка."
                }));
            }
        }
    }
}