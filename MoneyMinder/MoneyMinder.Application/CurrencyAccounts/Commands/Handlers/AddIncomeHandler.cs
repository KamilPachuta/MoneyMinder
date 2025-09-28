using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AddIncomeHandler : CurrencyHandler<AddIncomeCommand>
{

    public AddIncomeHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }
    
    public override async Task Handle(AddIncomeCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);

        var income = new Income(request.Name, request.Date, request.Currency, request.Amount);
        
        currencyAccount.AddIncome(income);

        await _repository.UpdateAsync(currencyAccount);
    }
}