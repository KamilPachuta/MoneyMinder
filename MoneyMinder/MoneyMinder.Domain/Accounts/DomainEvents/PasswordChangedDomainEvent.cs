using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record PasswordChangedDomainEvent(DateTime Date, Account Account) : IDomainEvent;