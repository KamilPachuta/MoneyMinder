using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record AccountCreatedDomainEvent(DateTime Date, Account Account) : IDomainEvent;