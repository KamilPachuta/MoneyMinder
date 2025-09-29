using MediatR;
using MoneyMinder.Application.SavingsAccounts.Exceptions;
using MoneyMinder.Application.SavingsAccounts.Services;
using MoneyMinder.Domain.Repositories;
using MoneyMinder.Domain.SavingsAccounts;

namespace MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;

internal abstract class SavingsHandler<TRequest> : IRequestHandler<TRequest>
    where TRequest : SavingsCommand
{
    protected readonly ISavingsAccountRepository _repository;
    protected readonly ISavingsAccountReadService _readService;

    public SavingsHandler(ISavingsAccountRepository repository, ISavingsAccountReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }
    
    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);

    protected async Task<SavingsAccount> GetSavingsAccount(SavingsCommand command)
    {
        var savingsAccount = await _repository.GetAsync(command.SavingsAccountId);

        if (savingsAccount is null)
        {
            throw new SavingsAccountNotFoundException(command.SavingsAccountId);
        }

        if (!await _readService.CheckOwner(command.AccountId, command.SavingsAccountId))
        {
            throw new SavingsAccountOwnershipException(command.AccountId, command.SavingsAccountId);
        }
        
        return savingsAccount;
    }
}