using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Savings.ValueObjects;

namespace MoneyMinder.Domain.Savings.DomainEvents;

public record PlannedAmountChangedDomainEvent(PositiveAmount OldAmount, PositiveAmount NewAmount, SavingsPortfolio SavingsPortfolio) : IDomainEvent;