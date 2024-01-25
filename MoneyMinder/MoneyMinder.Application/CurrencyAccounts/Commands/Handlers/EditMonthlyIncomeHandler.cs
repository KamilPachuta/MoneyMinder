using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class EditMonthlyIncomeHandler : CurrencyCommandHandler<EditMonthlyIncomeCommand>
{
    public EditMonthlyIncomeHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(EditMonthlyIncomeCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
        
        currencyAccount.EditMonthlyIncome(request.Name, request.NewName, request.NewAmount);

        await _repository.UpdateAsync(currencyAccount);
    }
}