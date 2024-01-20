using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Savings.ValueObjects;

namespace MoneyMinder.Domain.Savings.DomainEvents;

public record SavingsPortfolioNameChangedDomainEvent(SavingsPortfolioName OldName, SavingsPortfolioName NewName, SavingsPortfolio SavingsPortfolio) : IDomainEvent;