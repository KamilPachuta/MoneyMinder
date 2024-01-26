using MediatR;

namespace MoneyMinder.Application.Savings.Commands;

public record DeleteSavingsPortfolioCommand(Guid AccountId, Guid SavingsPortfolioId) : IRequest;