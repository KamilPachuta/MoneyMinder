using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Accounts.Entities;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record UserAddressChangedDomainEvent(Address OldAddress, Address NewAddress, Account Account) : IDomainEvent;