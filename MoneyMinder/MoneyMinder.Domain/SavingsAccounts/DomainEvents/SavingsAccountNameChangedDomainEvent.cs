using MoneyMinder.Domain.SavingsAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.DomainEvents;

public record SavingsAccountNameChangedDomainEvent(SavingsAccountName OldName, SavingsAccountName NewName, SavingsAccount SavingsAccount) : IDomainEvent;
