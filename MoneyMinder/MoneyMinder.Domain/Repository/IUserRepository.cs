using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Users;

namespace MoneyMinder.Domain.Repository;

public interface IUserRepository
{
    Task<User> GetAsync(Guid id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
}