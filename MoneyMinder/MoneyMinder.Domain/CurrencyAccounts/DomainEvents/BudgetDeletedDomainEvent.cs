using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record BudgetDeletedDomainEvent(Budget Budget, CurrencyAccount CurrencyAccount) : IDomainEvent;