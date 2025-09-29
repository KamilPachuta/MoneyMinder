using MoneyMinder.Domain.SavingsAccounts.ValueObjects;

namespace MoneyMinder.Application.SavingsAccounts.Services;

public interface ISavingsAccountReadService
{
    Task<bool> CheckOwner(Guid accountId, Guid savingsAccountId);
    Task<bool> CheckUnique(Guid accountId, SavingsAccountName name);
}