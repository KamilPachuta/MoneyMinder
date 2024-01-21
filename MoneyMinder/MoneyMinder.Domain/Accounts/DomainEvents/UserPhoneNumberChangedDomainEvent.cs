using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record UserPhoneNumberChangedDomainEvent(UserPhoneNumber OldPhoneNumber, UserPhoneNumber NewPhoneNumber, Account Account) : IDomainEvent;