using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentDeletedDomainEvent(MonthlyPayment MonthlyPayment, CurrencyAccount CurrencyAccount) : IDomainEvent;