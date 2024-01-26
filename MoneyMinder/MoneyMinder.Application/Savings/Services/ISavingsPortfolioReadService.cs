using MoneyMinder.Domain.SavingsPortfolios.ValueObjects;

namespace MoneyMinder.Application.Savings.Services;

public interface ISavingsPortfolioReadService
{
    Task<bool> CheckUnique(Guid accountId, SavingsPortfolioName name);
    Task<bool> CheckOwner(Guid accountId, Guid savingsPortfolioId);
}