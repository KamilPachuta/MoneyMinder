using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal class DeleteCurrencyAccountHandler : CurrencyHandler<DeleteCurrencyAccountCommand>
{
    public DeleteCurrencyAccountHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }
    
    public override async Task Handle(DeleteCurrencyAccountCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);
        
        await _repository.DeleteAsync(currencyAccount);
    }
}