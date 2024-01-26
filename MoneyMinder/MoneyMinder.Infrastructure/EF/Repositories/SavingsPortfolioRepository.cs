using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Repository;
using MoneyMinder.Domain.SavingsPortfolios;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.EF.Repositories;

internal sealed class SavingsPortfolioRepository : ISavingsPortfolioRepository
{
    private readonly DbSet<SavingsPortfolio> _savingsPortfolios;
    
    public SavingsPortfolioRepository(MoneyMinderDbContext dbContext)
    {
        _savingsPortfolios = dbContext.SavingsPortfolios;
    }

    public async Task<SavingsPortfolio> GetAsync(Guid id)
        => await _savingsPortfolios
            .Include(sp => sp.Transactions)
            .FirstOrDefaultAsync(sp => sp.Id == id);
    
    public async Task AddAsync(SavingsPortfolio savingsPortfolio)
        => await _savingsPortfolios.AddAsync(savingsPortfolio);


    public Task UpdateAsync(SavingsPortfolio savingsPortfolio)
    {
        _savingsPortfolios.Update(savingsPortfolio);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(SavingsPortfolio savingsPortfolio)
    {
        _savingsPortfolios.Remove(savingsPortfolio);
        return Task.CompletedTask;
    }
}