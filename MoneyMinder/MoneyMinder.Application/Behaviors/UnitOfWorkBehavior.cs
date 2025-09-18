using System.Transactions;
using MediatR;
using Microsoft.Extensions.Logging;
using MoneyMinder.Domain.Shared.UnitOfWork;

namespace MoneyMinder.Application.Behaviors;

public sealed class UnitOfWorkBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<UnitOfWorkBehavior<TRequest, TResponse>> _logger;
    private readonly IUnitOfWork _unitOfWork;
    
    public UnitOfWorkBehavior(IUnitOfWork unitOfWork, ILogger<UnitOfWorkBehavior<TRequest, TResponse>> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    
    public  async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (IsNotCommand())
        {
            return await next();
        }
        
        using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var response = await next();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            transactionScope.Complete();
            
            _logger.LogInformation("Unit of work successfully completed.");
            
            return response;
        }

    }
    
    private static bool IsNotCommand()
        => !typeof(TRequest).Name.EndsWith("Command");
}