using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AcceptMonthlyPaymentHandler : CurrencyCommandHandler<AcceptMonthlyPaymentCommand>
{
    public AcceptMonthlyPaymentHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(AcceptMonthlyPaymentCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
        
        currencyAccount.AcceptMonthlyPayment(request.Name, request.Amount, request.Currency);

        await _repository.UpdateAsync(currencyAccount);
    }
}