using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record PaymentAddedDomainEvent(Payment Payment, CurrencyAccount CurrencyAccount) : IDomainEvent;
