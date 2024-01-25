using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repository;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.EF.Repositories;

internal sealed class AccountRepository : IAccountRepository
{
    private readonly DbSet<Account> _accounts;

    public AccountRepository(MoneyMinderDbContext dbContext)
    {
        _accounts = dbContext.Accounts;
    }


    public async Task<Account> GetAsync(Guid id)
        => await _accounts
            .Include(a => a.User)
            .ThenInclude(u => u.Address)
            .Include(u => u.CurrencyAccounts)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Account> GetAsync(AccountEmail email)
        => await _accounts
            .FirstOrDefaultAsync(a => a.Email == email);
    
    public async Task AddAsync(Account account)
    {
        await _accounts.AddAsync(account);
    }

    public Task UpdateAsync(Account account)
    {
        _accounts.Update(account);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Account account)
    {
        _accounts.Remove(account);
        return Task.CompletedTask;
    }
}