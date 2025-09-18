using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record UserAddressChangedDomainEvent(Address OldAddress, Address NewAddress, Account Account) : IDomainEvent;