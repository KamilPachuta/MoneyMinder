using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class EditLimitHandler : CurrencyHandler<EditLimitCommand>
{
    public EditLimitHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override async Task Handle(EditLimitCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);
        
        var limit = new Limit(request.Limit.Category, request.Limit.Amount);;
        
        currencyAccount.EditLimit(limit);

        await _repository.UpdateAsync(currencyAccount);
    }
}