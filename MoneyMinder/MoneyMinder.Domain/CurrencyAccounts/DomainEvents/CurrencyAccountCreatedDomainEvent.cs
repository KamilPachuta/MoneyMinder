using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record CurrencyAccountCreatedDomainEvent(DateTime Date, CurrencyAccount CurrencyAccount) : IDomainEvent;