using System.Net;
using System.Text.Json;
using FluentValidation;
using Sk8ter.Application.Common.Exceptions;

namespace Sk8ter.Api.Middleware;

internal sealed class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
        
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var error = "";
        var errorCode = HttpStatusCode.InternalServerError;
        
        if (e is ValidationException validationException)
        {
            error = JsonSerializer.Serialize(validationException.Errors);
            errorCode = HttpStatusCode.BadRequest;
        }
        
        if (e is NotFoundException)
        {
            errorCode = HttpStatusCode.NotFound;
        }

        if (error == "")
        {
            error = JsonSerializer.Serialize(new { error = e.Message });
        }
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) errorCode;
        
        await context.Response.WriteAsync(error);
    }
}

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this
        IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}