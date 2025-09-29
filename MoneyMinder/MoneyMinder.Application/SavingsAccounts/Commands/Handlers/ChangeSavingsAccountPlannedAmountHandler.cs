using MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;
using MoneyMinder.Application.SavingsAccounts.Services;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.SavingsAccounts.Commands.Handlers;

internal sealed class ChangeSavingsAccountPlannedAmountHandler : SavingsHandler<ChangeSavingsAccountPlannedAmountCommand>
{
    public ChangeSavingsAccountPlannedAmountHandler(ISavingsAccountRepository repository, ISavingsAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override async Task Handle(ChangeSavingsAccountPlannedAmountCommand request, CancellationToken cancellationToken)
    {
        var savingsAccount = await GetSavingsAccount(request);
        
        savingsAccount.ChangePlannedAmount(request.PlannedAmount);
        
        await _repository.UpdateAsync(savingsAccount);
    }
}