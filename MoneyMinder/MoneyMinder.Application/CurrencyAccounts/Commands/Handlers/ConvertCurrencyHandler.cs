using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class ConvertCurrencyHandler: CurrencyHandler<ConvertCurrencyCommand>
{
    public ConvertCurrencyHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override async Task Handle(ConvertCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);
        
        currencyAccount.ConvertCurrency(request.From, request.To, request.Amount, request.Coefficient);
        
        await _repository.UpdateAsync(currencyAccount);
    }
}



