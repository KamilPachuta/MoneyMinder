using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Users.Entities;

namespace MoneyMinder.Domain.Users.DomainEvents;

public record UserAddressChangedDomainEvent(Address OldAddress, Address NewAddress, User User) : IDomainEvent;