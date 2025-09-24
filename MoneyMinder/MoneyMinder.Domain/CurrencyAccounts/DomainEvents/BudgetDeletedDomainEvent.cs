using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record BudgetDeletedDomainEvent(Budget Budget, CurrencyAccount CurrencyAccount) : IDomainEvent;