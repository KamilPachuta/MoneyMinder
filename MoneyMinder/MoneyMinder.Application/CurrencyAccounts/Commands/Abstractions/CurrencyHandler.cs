using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;

internal abstract class CurrencyHandler<TRequest> : IRequestHandler<TRequest>
    where TRequest : CurrencyCommand
{
    protected readonly ICurrencyAccountRepository _repository;
    protected readonly ICurrencyAccountReadService _readService;

    public CurrencyHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }
    
    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);

    protected async Task<CurrencyAccount> GetCurrencyAccount(CurrencyCommand command)
    {
        var currencyAccount = await _repository.GetAsync(command.CurrencyAccountId);

        if (currencyAccount is null)
        {
            throw new CurrencyAccountNotFoundException(command.CurrencyAccountId);
        }

        if (!await _readService.CheckOwner(command.AccountId, command.CurrencyAccountId))
        {
            throw new CurrencyAccountOwnershipException(command.AccountId, command.CurrencyAccountId);
        }
        
        return currencyAccount;
    }
}