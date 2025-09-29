using MoneyMinder.Application.SavingsAccounts.Services;
using MoneyMinder.Domain.Repositories;
using MoneyMinder.Domain.SavingsAccounts.ValueObjects;

namespace MoneyMinder.Infrastructure.EF.ReadServices;

internal sealed class SavingsAccountReadService : ISavingsAccountReadService
{
    private readonly IAccountRepository _repository;

    public SavingsAccountReadService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CheckOwner(Guid accountId, Guid savingsAccountId)
    {
        var account = await _repository.GetAsync(accountId);

        return account.SavingsAccounts.Exists(ca => ca.Id == savingsAccountId);
    }

    public async Task<bool> CheckUnique(Guid accountId, SavingsAccountName name)
    {
        var account = await _repository.GetAsync(accountId);

        return !account.SavingsAccounts.Exists(ca => ca.Name == name);
    }
}