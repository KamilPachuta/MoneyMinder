using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record MonthlyPaymentAcceptedDomainEvent(MonthlyPayment MonthlyPayment, Payment Payment, CurrencyAccount CurrencyAccount) : IDomainEvent;