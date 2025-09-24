using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record PaymentRemovedDomainEvent(Payment Payment, CurrencyAccount CurrencyAccount) : IDomainEvent;