using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.SavingsPortfolios;
using MoneyMinder.Domain.SavingsPortfolios.ValueObjects;

namespace MoneyMinder.Domain.Factories;

public class SavingsPortfolioFactory : ISavingsPortfolioFactory
{
    public SavingsPortfolio Create(SavingsPortfolioName name, Currency currency, PositiveAmount plannedAmount, Account account)
    {
        var id = Guid.NewGuid();
        
        var savingsPortfolio = new SavingsPortfolio(id, name, currency, plannedAmount, 0, account);
        
        return savingsPortfolio;
    }
}