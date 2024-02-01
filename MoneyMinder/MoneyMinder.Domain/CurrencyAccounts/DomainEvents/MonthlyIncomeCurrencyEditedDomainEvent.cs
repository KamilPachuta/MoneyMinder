using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;


public record MonthlyIncomeCurrencyEditedDomainEvent(
     Currency NewCurrency, 
    Currency OldCurrency, 
    CurrencyAccount CurrencyAccount)
    : IDomainEvent;