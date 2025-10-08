using MediatR;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Application.SavingsAccounts.Queries;

public record GetSavingsAccountsDetailsQuery(Guid AccountId) : IRequest<GetSavingsAccountsDetailsResponse>;
