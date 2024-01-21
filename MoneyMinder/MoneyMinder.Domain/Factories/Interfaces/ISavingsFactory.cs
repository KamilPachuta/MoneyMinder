using System.Security.Cryptography;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.Savings;
using MoneyMinder.Domain.Savings.DomainEvents;
using MoneyMinder.Domain.Savings.ValueObjects;

namespace MoneyMinder.Domain.Factories.Interfaces;

public interface ISavingsFactory
{
    SavingsPortfolio Create(SavingsPortfolioName name, Currency currency,PositiveAmount plannedAmount,PositiveAmount actualAmount);
}