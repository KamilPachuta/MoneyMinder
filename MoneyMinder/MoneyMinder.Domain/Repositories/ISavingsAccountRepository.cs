using MoneyMinder.Domain.SavingsAccounts;

namespace MoneyMinder.Domain.Repositories;

public interface ISavingsAccountRepository
{
    Task<SavingsAccount> GetAsync(Guid id);
    Task AddAsync(SavingsAccount savingsAccount);
    Task UpdateAsync(SavingsAccount savingsAccount);
    Task DeleteAsync(SavingsAccount savingsAccount);
}