using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyIncomeEditedDomainEvent(TransactionName OldName, TransactionName NewName, 
    Amount OldAmount, Amount NewAmount, Currency OldCurrency, Currency NewCurrency, CurrencyAccount CurrencyAccount)
    : IDomainEvent;