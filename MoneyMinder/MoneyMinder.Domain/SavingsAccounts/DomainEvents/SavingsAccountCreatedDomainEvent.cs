using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.DomainEvents;

public record SavingsAccountCreatedDomainEvent(DateTime Date, SavingsAccount SavingsAccount) : IDomainEvent;