using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentEditedDomainEvent(TransactionName OldName, TransactionName NewName, 
    Amount OldAmount, Amount NewAmount, 
    Currency OldCurrency, Currency NewCurrency, 
    CategoryName OldCategoryName, CategoryName NewCategoryName,
    CurrencyAccount CurrencyAccount) 
    : IDomainEvent;