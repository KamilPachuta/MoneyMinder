using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Savings;
using MoneyMinder.Domain.Savings.ValueObjects;

namespace MoneyMinder.Domain.Factories;

public class SavingsFactory : ISavingsFactory
{
    public SavingsPortfolio Create(SavingsPortfolioName name, Currency currency, PositiveAmount plannedAmount,
        PositiveAmount actualAmount)
    {
        var id = Guid.NewGuid();
        
        var savingsPortfolio = new SavingsPortfolio(id, name, currency, plannedAmount, actualAmount);
        
        return savingsPortfolio;
    }
}