using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class RemoveMonthlyIncomeHandler : CurrencyCommandHandler<RemoveMonthlyIncomeCommand>
{
    public RemoveMonthlyIncomeHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(RemoveMonthlyIncomeCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
        
        currencyAccount.RemoveMonthlyIncome(request.MonthlyIncomeName);

        await _repository.UpdateAsync(currencyAccount);
    }
}