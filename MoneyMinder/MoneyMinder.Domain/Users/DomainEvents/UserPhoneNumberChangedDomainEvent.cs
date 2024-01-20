using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.Users.DomainEvents;

public record UserPhoneNumberChangedDomainEvent(UserPhoneNumber oldPhoneNumber, UserPhoneNumber newPhoneNumber, User User) : IDomainEvent;