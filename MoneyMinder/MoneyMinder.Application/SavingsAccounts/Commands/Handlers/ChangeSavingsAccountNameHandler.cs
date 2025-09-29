using MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;
using MoneyMinder.Application.SavingsAccounts.Exceptions;
using MoneyMinder.Application.SavingsAccounts.Services;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.SavingsAccounts.Commands.Handlers;

internal sealed class ChangeSavingsAccountNameHandler : SavingsHandler<ChangeSavingsAccountNameCommand>
{
    public ChangeSavingsAccountNameHandler(ISavingsAccountRepository repository, ISavingsAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override async Task Handle(ChangeSavingsAccountNameCommand request, CancellationToken cancellationToken)
    {
        var savingsAccount = await GetSavingsAccount(request);

        if (!await _readService.CheckUnique(request.AccountId, request.Name))
        {
            throw new SavingsAccountAlreadyExistException(request.Name);
        }
        
        savingsAccount.ChangeName(request.Name);
        
        await _repository.UpdateAsync(savingsAccount);
    }
}