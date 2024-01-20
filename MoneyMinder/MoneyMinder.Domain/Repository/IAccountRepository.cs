using MoneyMinder.Domain.Accounts;

namespace MoneyMinder.Domain.Repository;

public interface IAccountRepository
{
    Task<Account> GetAsync(Guid id);
    Task AddAsync(Account account);
    Task UpdateAsync(Account account);
    Task DeleteAsync(Account account);
}