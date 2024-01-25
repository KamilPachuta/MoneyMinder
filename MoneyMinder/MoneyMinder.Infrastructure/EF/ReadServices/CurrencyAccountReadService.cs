using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Infrastructure.EF.ReadServices;

public class CurrencyAccountReadService : ICurrencyAccountReadService
{
    private readonly IAccountRepository _repository;

    public CurrencyAccountReadService(IAccountRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> CheckUnique(Guid accountId, CurrencyAccountName name)
    {
        var account = await _repository.GetAsync(accountId);

        return account.CurrencyAccounts.Exists(ca => ca.Name == name);
    }

    public async Task<bool> CheckOwner(Guid accountId, Guid currencyAccountId)
    {
        var account = await _repository.GetAsync(accountId);

        return !account.CurrencyAccounts.Exists(ca => ca.Id == currencyAccountId);
    }
}