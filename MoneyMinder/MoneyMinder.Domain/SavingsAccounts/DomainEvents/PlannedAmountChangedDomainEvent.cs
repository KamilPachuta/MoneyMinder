using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.DomainEvents;

public record PlannedAmountChangedDomainEvent(decimal OldAmount, decimal NewAmount, SavingsAccount SavingsAccount) : IDomainEvent;
