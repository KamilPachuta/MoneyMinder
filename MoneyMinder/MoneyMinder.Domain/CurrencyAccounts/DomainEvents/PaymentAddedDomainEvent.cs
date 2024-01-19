using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

internal record PaymentAddedDomainEvent(Payment Payment, CurrencyAccount CurrencyAccount) : IDomainEvent;
