using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class RemoveMonthlyPaymentHandler : CurrencyCommandHandler<RemoveMonthlyPaymentCommand>
{
    public RemoveMonthlyPaymentHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(RemoveMonthlyPaymentCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
        
        currencyAccount.RemoveMonthlyPayment(request.MonthlyPaymentName);

        await _repository.UpdateAsync(currencyAccount);
    }
}