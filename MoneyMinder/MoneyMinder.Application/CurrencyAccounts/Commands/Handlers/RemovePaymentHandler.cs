using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class RemovePaymentHandler : CurrencyHandler<RemovePaymentCommand>
{
    public RemovePaymentHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) : base(repository, readService)
    {
    }

    public async override Task Handle(RemovePaymentCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);

        // var payment = currencyAccount.Payments.FirstOrDefault(i => i.Id == request.PaymentId);
        //
        // if (payment is null)
        // {
        //     throw new PaymentNotFoundException(request.PaymentId);
        // }
        
        currencyAccount.RemovePayment(request.PaymentId);

        await _repository.UpdateAsync(currencyAccount);

    }
}