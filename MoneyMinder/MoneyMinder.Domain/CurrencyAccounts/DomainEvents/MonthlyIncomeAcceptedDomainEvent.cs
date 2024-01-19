using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyIncomeAcceptedDomainEvent(MonthlyIncome MonthlyIncome, Income Income, CurrencyAccount CurrencyAccount) : IDomainEvent;