using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AcceptMonthlyIncomeHandler : CurrencyCommandHandler<AcceptMonthlyIncomeCommand>
{
    public AcceptMonthlyIncomeHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(AcceptMonthlyIncomeCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
        
        currencyAccount.AcceptMonthlyIncome(request.Name, request.Amount);

        await _repository.UpdateAsync(currencyAccount);
    }
}