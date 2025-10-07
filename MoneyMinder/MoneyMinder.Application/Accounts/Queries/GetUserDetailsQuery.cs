using MediatR;
using MoneyMinderContracts.Responses.Accounts;

namespace MoneyMinder.Application.Accounts.Queries;

public record GetUserDetailsQuery(Guid AccountId) : IRequest<GetUserDetailsResponse>;