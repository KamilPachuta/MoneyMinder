using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentNameEditedDomainEvent(
    TransactionName OldName, 
    TransactionName NewName, 
    CurrencyAccount CurrencyAccount) 
    : IDomainEvent;