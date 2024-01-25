using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AddIncomeHandler : CurrencyCommandHandler<AddIncomeCommand>
{

    public AddIncomeHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) : base(repository, readService)
    {
    }
    
    public override async Task Handle(AddIncomeCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);

        var income = new Income(request.Name, request.Date, request.Currency, request.Amount);
        
        currencyAccount.AddIncome(income);

        await _repository.UpdateAsync(currencyAccount);
    }
}