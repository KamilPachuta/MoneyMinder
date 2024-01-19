using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyIncomeDeletedDomainEvent(MonthlyIncome MonthlyIncome, CurrencyAccount CurrencyAccount) : IDomainEvent;