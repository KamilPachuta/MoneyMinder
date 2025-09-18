using MediatR;
using Microsoft.Extensions.Logging;

namespace MoneyMinder.Application.Behaviors;

public sealed class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting request: {@RequestName}, {DateTimeUtc}", 
            typeof(TRequest).Name, 
            DateTime.UtcNow);
        
        var result = await next();
        
        _logger.LogInformation("Request completed: {@RequestName}, {@DateTimeUtc}", 
            typeof(TRequest).Name, 
            DateTime.UtcNow);
        
        return result;
    }
}