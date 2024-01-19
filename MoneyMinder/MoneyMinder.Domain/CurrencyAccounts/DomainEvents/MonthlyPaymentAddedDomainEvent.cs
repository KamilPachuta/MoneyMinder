using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentAddedDomainEvent(MonthlyPayment MonthlyPayment, CurrencyAccount CurrencyAccount) : IDomainEvent;
