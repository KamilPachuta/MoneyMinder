using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.SavingsPortfolios;
using MoneyMinder.Domain.SavingsPortfolios.ValueObjects;

namespace MoneyMinder.Domain.Factories.Interfaces;

public interface ISavingsPortfolioFactory
{
    SavingsPortfolio Create(SavingsPortfolioName name, Currency currency,PositiveAmount plannedAmount, Account account);
}