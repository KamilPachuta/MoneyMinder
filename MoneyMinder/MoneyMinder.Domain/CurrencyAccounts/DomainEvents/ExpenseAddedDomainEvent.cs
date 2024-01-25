using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record ExpenseAddedDomainEvent(Expense Expense, CurrencyAccount CurrencyAccount) : IDomainEvent;