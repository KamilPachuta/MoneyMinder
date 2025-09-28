using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Repositories;
using MoneyMinder.Domain.SavingsAccounts;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.EF.Repositories;

internal sealed class SavingsAccountRepository : ISavingsAccountRepository
{
    private readonly DbSet<SavingsAccount> _savingsAccounts;
    
    public SavingsAccountRepository(MoneyMinderDbContext dbContext)
    {
        _savingsAccounts = dbContext.SavingsAccounts;
    }
    
    public async Task<SavingsAccount> GetAsync(Guid id)
        => await _savingsAccounts
            .Include(sp => sp.Transactions)
            .FirstOrDefaultAsync(sp => sp.Id == id);
    
    public async Task AddAsync(SavingsAccount savingsAccount)
        => await _savingsAccounts.AddAsync(savingsAccount);


    public Task UpdateAsync(SavingsAccount savingsAccount)
    {
        _savingsAccounts.Update(savingsAccount);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(SavingsAccount savingsAccount)
    {
        _savingsAccounts.Remove(savingsAccount);
        return Task.CompletedTask;
    }
}