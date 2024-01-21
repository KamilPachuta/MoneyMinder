using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record UserNameChangedDomainEvent(UserName OldName, UserName NewName, Account Account) : IDomainEvent;