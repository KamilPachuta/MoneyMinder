using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record BudgetCreatedDomainEvent(Budget? OldBudget, Budget NewBudget, CurrencyAccount CurrencyAccount) : IDomainEvent;