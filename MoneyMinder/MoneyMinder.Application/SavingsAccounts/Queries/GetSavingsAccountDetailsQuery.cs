using MediatR;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Application.SavingsAccounts.Queries;

public record GetSavingsAccountDetailsQuery(Guid AccountId, string Name) : IRequest<GetSavingsAccountDetailsResponse>;
