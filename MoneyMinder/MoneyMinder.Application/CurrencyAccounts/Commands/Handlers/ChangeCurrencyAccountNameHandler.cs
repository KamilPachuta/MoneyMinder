using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class ChangeCurrencyAccountNameHandler : CurrencyHandler<ChangeCurrencyAccountNameCommand>
{
    public ChangeCurrencyAccountNameHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }
    
    public override async Task Handle(ChangeCurrencyAccountNameCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurrencyAccount(request);
        
        if (!await _readService.CheckUnique(request.AccountId,request.Name))
        {
            throw new CurrencyAccountAlreadyExistException(request.Name);
        }
        
        currencyAccount.ChangeName(request.Name);

        await _repository.UpdateAsync(currencyAccount);
    }
}