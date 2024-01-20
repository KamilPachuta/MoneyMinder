using MoneyMinder.Domain.Savings;

namespace MoneyMinder.Domain.Repository;

public interface ISavingsRepository
{
    Task<SavingsPortfolio> GetAsync(Guid id);
    Task AddAsync(SavingsPortfolio savingsPortfolio);
    Task UpdateAsync(SavingsPortfolio savingsPortfolio);
    Task DeleteAsync(SavingsPortfolio savingsPortfolio);
}