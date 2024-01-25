using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AddMonthlyIncomeHandler : CurrencyCommandHandler<AddMonthlyIncomeCommand>
{
    public AddMonthlyIncomeHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(AddMonthlyIncomeCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);

        var monthlyIncome = new MonthlyIncome(request.Name, request.Date, request.Currency, request.Amount);
        
        currencyAccount.AddMonthlyIncome(monthlyIncome);

        await _repository.UpdateAsync(currencyAccount);
    }
}