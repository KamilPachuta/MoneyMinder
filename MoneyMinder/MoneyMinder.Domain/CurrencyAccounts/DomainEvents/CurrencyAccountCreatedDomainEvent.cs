using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record CurrencyAccountCreatedDomainEvent(DateTime Date, CurrencyAccount CurrencyAccount) : IDomainEvent;