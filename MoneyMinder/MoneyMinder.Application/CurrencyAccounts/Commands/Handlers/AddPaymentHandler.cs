using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AddPaymentHandler : CurrencyHandler<AddPaymentCommand>
{
    public AddPaymentHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override async Task Handle(AddPaymentCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);

        var payment = new Payment(request.Name, request.Date, request.Currency, request.Amount, request.Category);
        
        currencyAccount.AddPayment(payment);

        await _repository.UpdateAsync(currencyAccount);
    }
}