using MediatR;
using MoneyMinderContracts.Responses.Accounts;

namespace MoneyMinder.Application.Accounts.Queries;

public record GetUserNameQuery(Guid AccountId) : IRequest<GetUserNameResponse>;