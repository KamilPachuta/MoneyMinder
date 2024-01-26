using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class RemovePaymentHandler : CurrencyCommandHandler<RemovePaymentCommand>
{
    public RemovePaymentHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) : base(repository, readService)
    {
    }

    public async override Task Handle(RemovePaymentCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);

        var payment = currencyAccount.Payments.FirstOrDefault(i => i.Id == request.PaymentId);

        if (payment is null)
        {
            throw new PaymentNotFoundException(request.PaymentId);
        }
        
        currencyAccount.RemovePayment(payment);

        await _repository.UpdateAsync(currencyAccount);

    }
}