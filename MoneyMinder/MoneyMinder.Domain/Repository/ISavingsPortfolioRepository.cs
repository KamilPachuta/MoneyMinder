using MoneyMinder.Domain.SavingsPortfolios;

namespace MoneyMinder.Domain.Repository;

public interface ISavingsPortfolioRepository
{
    Task<SavingsPortfolio> GetAsync(Guid id);
    Task AddAsync(SavingsPortfolio savingsPortfolio);
    Task UpdateAsync(SavingsPortfolio savingsPortfolio);
    Task DeleteAsync(SavingsPortfolio savingsPortfolio);
}