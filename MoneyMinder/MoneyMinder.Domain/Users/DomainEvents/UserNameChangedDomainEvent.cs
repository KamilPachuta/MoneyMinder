using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.Users.DomainEvents;

public record UserNameChangedDomainEvent(UserName OldName, UserName NewName, User User) : IDomainEvent;