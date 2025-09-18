using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record UserNameChangedDomainEvent(UserName OldName, UserName NewName, Account Account) : IDomainEvent;