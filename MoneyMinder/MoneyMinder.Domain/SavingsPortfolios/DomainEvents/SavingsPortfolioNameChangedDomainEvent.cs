using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.SavingsPortfolios.ValueObjects;

namespace MoneyMinder.Domain.SavingsPortfolios.DomainEvents;

public record SavingsPortfolioNameChangedDomainEvent(SavingsPortfolioName OldName, SavingsPortfolioName NewName, SavingsPortfolio SavingsPortfolio) : IDomainEvent;