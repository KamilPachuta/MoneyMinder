using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.SavingsPortfolios.ValueObjects;

namespace MoneyMinder.Domain.SavingsPortfolios.DomainEvents;

public record PlannedAmountChangedDomainEvent(PositiveAmount OldAmount, PositiveAmount NewAmount, SavingsPortfolio SavingsPortfolio) : IDomainEvent;