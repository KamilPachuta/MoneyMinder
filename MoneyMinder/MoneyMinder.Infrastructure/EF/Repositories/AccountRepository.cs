using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repository;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.EF.Repositories;

internal sealed class AccountRepository : IAccountRepository
{
    private readonly MoneyMinderDbContext _dbContext;
    private readonly DbSet<Account> _accounts;

    public AccountRepository(MoneyMinderDbContext dbContext)
    {
        _dbContext = dbContext;
        _accounts = dbContext.Accounts;
    }


    public async Task<Account> GetAsync(Guid id)
        => await _accounts
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(Account account)
    {
        await _accounts.AddAsync(account);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Account account)
    {
        _accounts.Update(account);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(Account account)
    {
        _accounts.Remove(account);
        await _dbContext.SaveChangesAsync();
    }
}