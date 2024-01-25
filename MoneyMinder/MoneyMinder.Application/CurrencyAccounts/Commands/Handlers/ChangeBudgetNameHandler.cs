using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class ChangeBudgetNameHandler : CurrencyCommandHandler<ChangeBudgetNameCommand>
{
    public ChangeBudgetNameHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(ChangeBudgetNameCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
        
        currencyAccount.ChangeBudgetName(request.Name);

        await _repository.UpdateAsync(currencyAccount);
    }
}