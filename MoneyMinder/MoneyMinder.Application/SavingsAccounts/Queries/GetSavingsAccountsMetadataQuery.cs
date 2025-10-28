using MediatR;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Application.SavingsAccounts.Queries;

public record GetSavingsAccountsMetadataQuery(Guid AccountId) : IRequest<GetSavingsAccountsMetadataResponse>;