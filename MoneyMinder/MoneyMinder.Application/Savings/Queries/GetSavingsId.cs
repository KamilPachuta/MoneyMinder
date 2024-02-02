using MediatR;

namespace MoneyMinder.Application.Savings.Queries;

public record GetSavingsId(string Name, Guid AccountId) : IRequest<Guid>;