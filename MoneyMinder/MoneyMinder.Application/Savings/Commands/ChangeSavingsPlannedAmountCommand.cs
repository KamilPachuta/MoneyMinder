using MediatR;

namespace MoneyMinder.Application.Savings.Commands;

public record ChangeSavingsPlannedAmountCommand(Guid AccountId, Guid SavingsPortfolioId, decimal PlannedAmount) : IRequest;