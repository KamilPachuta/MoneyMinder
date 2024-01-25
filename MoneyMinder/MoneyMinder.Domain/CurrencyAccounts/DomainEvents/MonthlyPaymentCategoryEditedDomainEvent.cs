using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentCategoryEditedDomainEvent(
    TransactionName Name, 
    Category OldCategory, 
    Category NewCategory, 
    CurrencyAccount CurrencyAccount) 
    : IDomainEvent;