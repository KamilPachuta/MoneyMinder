using MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;
using MoneyMinder.Application.SavingsAccounts.Services;
using MoneyMinder.Domain.Repositories;
using MoneyMinder.Domain.SavingsAccounts.Entities;

namespace MoneyMinder.Application.SavingsAccounts.Commands.Handlers;

internal sealed class ProcessSavingsTransactionHandler : SavingsHandler<ProcessSavingsTransactionCommand>
{
    public ProcessSavingsTransactionHandler(ISavingsAccountRepository repository, ISavingsAccountReadService readService) 
        : base(repository, readService)
    {
    }
    
    public override async Task Handle(ProcessSavingsTransactionCommand request, CancellationToken cancellationToken)
    {
        var savingsAccount = await GetSavingsAccount(request);
        
        var transaction = new SavingsTransaction(request.Name, request.Date, request.Currency, request.Amount, request.TransactionType);
        
        savingsAccount.ProcessTransaction(transaction);
        
        await _repository.UpdateAsync(savingsAccount);
    }
}   