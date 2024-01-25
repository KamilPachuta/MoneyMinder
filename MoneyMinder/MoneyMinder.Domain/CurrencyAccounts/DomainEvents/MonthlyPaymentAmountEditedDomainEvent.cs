using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentAmountEditedDomainEvent(
    TransactionName Name, 
    Amount OldAmount, 
    Amount NewAmount, 
    CurrencyAccount CurrencyAccount) 
    : IDomainEvent;