using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

internal abstract class CurrencyCommandHandler<TRequest> : IRequestHandler<TRequest>
    where TRequest : CurrencyCommand
{
    protected readonly ICurrencyAccountRepository _repository;
    protected readonly ICurrencyAccountReadService _readService;

    public CurrencyCommandHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }
    
    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);

    protected async Task<CurrencyAccount> GetCurremcyAccount(Guid accountId, Guid currencyAccountId)
    {
        var currencyAccount = await _repository.GetAsync(currencyAccountId);

        if (currencyAccount is null)
        {
            throw new CurrencyAccountNotFoundException(currencyAccountId);
        }

        if (await _readService.CheckOwner(accountId, currencyAccountId))
        {
            throw new AccesDeniedException(accountId, currencyAccountId);
        }
        
        return currencyAccount;
    }

    
}