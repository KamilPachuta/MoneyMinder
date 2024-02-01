using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class EditMonthlyPaymentHandler : CurrencyCommandHandler<EditMonthlyPaymentCommand>
{
    public EditMonthlyPaymentHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(EditMonthlyPaymentCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
        
        currencyAccount.EditMonthlyPayment(request.Name, request.NewAmount, request.NewCurrency);

        await _repository.UpdateAsync(currencyAccount);

    }
}