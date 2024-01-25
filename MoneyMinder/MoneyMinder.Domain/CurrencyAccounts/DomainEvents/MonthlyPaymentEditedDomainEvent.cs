using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentEditedDomainEvent(TransactionName OldName, TransactionName NewName, 
    Amount OldAmount, Amount NewAmount, 
    Category OldCategoryName, Category NewCategoryName,
    CurrencyAccount CurrencyAccount) 
    : IDomainEvent;