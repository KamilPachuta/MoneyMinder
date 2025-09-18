using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record PasswordChangedDomainEvent(DateTime Date, Account Account) : IDomainEvent;