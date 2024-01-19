using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record PasswordChangedDomainEvent(Account Account) : IDomainEvent;