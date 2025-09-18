using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.DomainEvents;

public record UserPhoneNumberChangedDomainEvent(UserPhoneNumber OldPhoneNumber, UserPhoneNumber NewPhoneNumber, Account Account) : IDomainEvent;