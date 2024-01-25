using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record ExpenseDeletedDomainEvent(Category Category, CurrencyAccount CurrencyAccount) : IDomainEvent;