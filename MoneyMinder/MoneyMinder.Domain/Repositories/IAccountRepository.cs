using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Domain.Repositories;

public interface IAccountRepository
{
    Task<Account> GetAsync(Guid id);
    Task<Account> GetAsync(AccountEmail email);
    Task AddAsync(Account account);
    Task UpdateAsync(Account account);
    Task DeleteAsync(Account account);
}