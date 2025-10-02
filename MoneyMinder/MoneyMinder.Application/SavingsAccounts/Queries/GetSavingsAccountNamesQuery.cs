using MediatR;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Application.SavingsAccounts.Queries;

public record GetSavingsAccountNamesQuery(Guid AccountId) : IRequest<GetSavingsAccountNamesResponse>;
