using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AddPaymentHandler : CurrencyCommandHandler<AddPaymentCommand>
{
    public AddPaymentHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(AddPaymentCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);

        var payment = new Payment(request.Name, request.Date, request.Currency, request.Amount, request.Category);
        
        currencyAccount.AddPayment(payment);

        await _repository.UpdateAsync(currencyAccount);
    }
}