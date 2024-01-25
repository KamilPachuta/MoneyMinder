using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;


public record MonthlyIncomeNameEditedDomainEvent(
    TransactionName OldName, 
    TransactionName NewName, 
    CurrencyAccount CurrencyAccount)
    : IDomainEvent;