using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class CreateBudgetHandler : CurrencyHandler<CreateBudgetCommand>
{
    public CreateBudgetHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);

        var limits = request.Limits
            .Select(lm => new Limit(lm.Category, lm.Amount))
            .ToList();
        
        var budget = new Budget(request.Date, request.Currency, limits);
        
        currencyAccount.CreateBudget(budget);

        await _repository.UpdateAsync(currencyAccount);
    }
}