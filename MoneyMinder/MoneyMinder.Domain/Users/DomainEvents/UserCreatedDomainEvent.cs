using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.DomainEvents;

public record UserCreatedDomainEvent(DateTime CreatedAt, User User) : IDomainEvent;