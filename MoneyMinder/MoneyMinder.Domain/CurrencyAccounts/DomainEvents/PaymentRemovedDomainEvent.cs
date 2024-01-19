using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record PaymentRemovedDomainEvent(Payment Payment, CurrencyAccount CurrencyAccount) : IDomainEvent;