using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentCurrencyEditedDomainEvent(
    TransactionName Name, 
    Currency OldCurrency, 
    Currency NewCurrency, 
    CurrencyAccount CurrencyAccount) 
    : IDomainEvent;