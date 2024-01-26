using MediatR;

namespace MoneyMinder.Application.Savings.Commands;

public record ChangeSavingsNameCommand(Guid AccountId, Guid SavingsPortfolioId, string Name) : IRequest;