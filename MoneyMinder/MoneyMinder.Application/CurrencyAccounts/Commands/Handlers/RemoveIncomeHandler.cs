using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class RemoveIncomeHandler : CurrencyCommandHandler<RemoveIncomeCommand>
{
    public RemoveIncomeHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(RemoveIncomeCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);

        var income = currencyAccount.Incomes.FirstOrDefault(i => i.Id == request.IncomeId);

        if (income is null)
        {
            throw new IncomeNotFoundException(request.IncomeId);
        }
        
        currencyAccount.RemoveIncome(income);

        await _repository.UpdateAsync(currencyAccount);

    }
}