using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record ExpenseEditedDomainEvent(Expense Expens, ExpenseAmount OldAmount, CurrencyAccount CurrencyAccount) : IDomainEvent;