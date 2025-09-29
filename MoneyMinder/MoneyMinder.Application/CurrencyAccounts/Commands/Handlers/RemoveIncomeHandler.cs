using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class RemoveIncomeHandler : CurrencyHandler<RemoveIncomeCommand>
{
    public RemoveIncomeHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override async Task Handle(RemoveIncomeCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);
        
        currencyAccount.RemoveIncome(request.IncomeId);

        await _repository.UpdateAsync(currencyAccount);

    }
}