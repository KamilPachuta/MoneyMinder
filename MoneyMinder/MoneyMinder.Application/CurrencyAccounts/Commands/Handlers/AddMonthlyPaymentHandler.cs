using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AddMonthlyPaymentHandler : CurrencyCommandHandler<AddMonthlyPaymentCommand>
{
    public AddMonthlyPaymentHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(AddMonthlyPaymentCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);

        var monthlyPayment = new MonthlyPayment(request.Name, request.Date, request.Currency, request.Amount, request.Category);
        
        currencyAccount.AddMonthlyPayment(monthlyPayment);

        await _repository.UpdateAsync(currencyAccount);
    }
}