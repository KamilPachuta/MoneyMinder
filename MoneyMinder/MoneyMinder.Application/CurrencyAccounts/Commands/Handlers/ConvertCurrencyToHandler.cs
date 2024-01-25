using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class ConvertCurrencyToHandler : CurrencyCommandHandler<ConvertCurrencyToCommand>
{
    public ConvertCurrencyToHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(ConvertCurrencyToCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
        
        currencyAccount.ConvertCurrencyTo(request.From, request.To, request.Amount, request.Coefficient);

        await _repository.UpdateAsync(currencyAccount);
    }
}