using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.SavingsPortfolios.Entities;

namespace MoneyMinder.Domain.SavingsPortfolios.DomainEvents;

public record SavingsTransactionProcessedDomainEvent(SavingsTransaction Transaction, SavingsPortfolio SavingsPortfolio) : IDomainEvent;