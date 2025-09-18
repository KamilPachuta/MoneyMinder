using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record AccountLoggedInDomainEvent(DateTime Date, Account Account) : IDomainEvent;
