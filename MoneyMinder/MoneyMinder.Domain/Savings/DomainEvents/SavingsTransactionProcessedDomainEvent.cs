using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Savings.Entities;

namespace MoneyMinder.Domain.Savings.DomainEvents;

public record SavingsTransactionProcessedDomainEvent(SavingsTransaction Transaction, SavingsPortfolio SavingsPortfolio) : IDomainEvent;