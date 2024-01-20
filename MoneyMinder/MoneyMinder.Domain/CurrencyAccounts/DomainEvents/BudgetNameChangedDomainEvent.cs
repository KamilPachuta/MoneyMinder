using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record BudgetNameChangedDomainEvent(BudgetName OldName, BudgetName NewName, CurrencyAccount CurrencyAccount) : IDomainEvent;