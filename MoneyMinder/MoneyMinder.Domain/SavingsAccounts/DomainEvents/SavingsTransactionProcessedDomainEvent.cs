using MoneyMinder.Domain.SavingsAccounts.Entities;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.DomainEvents;

public record SavingsTransactionProcessedDomainEvent(SavingsTransaction SavingsTransaction, SavingsAccount SavingsAccount) : IDomainEvent;