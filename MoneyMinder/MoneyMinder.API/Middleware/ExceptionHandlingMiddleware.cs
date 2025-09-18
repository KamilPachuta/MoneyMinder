using Microsoft.AspNetCore.Mvc;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (MoneyMinderException ex)
        {
            _logger.LogError(ex, "Exception occurred: {@ExceptionName}, Message: '{Message}', {DateTimeUtc}",
                ex.GetType().Name,
                ex.Message,
                DateTime.UtcNow);

            var problemDetails = new ProblemDetails();
            problemDetails.Status = StatusCodes.Status400BadRequest;
            problemDetails.Title = ex.GetType().Name;
            problemDetails.Instance = context.Request.Path;
            problemDetails.Extensions.Add("traceId", context.TraceIdentifier);
            problemDetails.Detail = string.Concat(
                $"Exception occurred: '{ex.GetType().Name}'." +
                $"Message: '{ex.Message}'");

            context.Response.StatusCode =
                StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occurred: {@ExceptionName}, Message: '{Message}', {DateTimeUtc}",
            ex.GetType().Name,
            ex.Message,
            DateTime.UtcNow);
            
            var problemDetails = new ProblemDetails();
            problemDetails.Status = StatusCodes.Status500InternalServerError;
            problemDetails.Title = ex.GetType().Name;
            problemDetails.Instance = context.Request.Path;
            problemDetails.Extensions.Add("traceId", context.TraceIdentifier);
            problemDetails.Detail = string.Concat(
                $"Exception occurred: '{ex.GetType().Name}'." +
                $"Message: '{ex.Message}'");

            context.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        
    }
}