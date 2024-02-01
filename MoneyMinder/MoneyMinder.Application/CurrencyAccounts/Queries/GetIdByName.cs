using MediatR;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetIdByName(string Name, Guid AccountId) : IRequest<Guid>;