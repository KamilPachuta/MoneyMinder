using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repository;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.EF.Repositories;

internal sealed class CurrencyAccountRepository : ICurrencyAccountRepository
{
    private DbSet<CurrencyAccount> _currencyAccounts;
    
    public CurrencyAccountRepository(MoneyMinderDbContext dbContext)
    {
        _currencyAccounts = dbContext.CurrencyAccounts;
    }

    public async Task<CurrencyAccount> GetAsync(Guid id)
        => await _currencyAccounts
            .Include(ca => ca.Budget)
            .ThenInclude(b => b.Expenses)
            .Include(ca => ca.Balances)
            .Include(ca => ca.Incomes)
            .Include(ca => ca.Payments)
            .Include(ca =>ca.MonthlyIncomes)
            .Include(ca => ca.MonthlyPayments)
            .FirstOrDefaultAsync(ca => ca.Id == id);

    public async Task AddAsync(CurrencyAccount currencyAccount)
        => await _currencyAccounts.AddAsync(currencyAccount);

    public Task UpdateAsync(CurrencyAccount currencyAccount)
    {
        _currencyAccounts.Update(currencyAccount);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(CurrencyAccount currencyAccount)
    {
        _currencyAccounts.Remove(currencyAccount);
        return Task.CompletedTask;
    }
}