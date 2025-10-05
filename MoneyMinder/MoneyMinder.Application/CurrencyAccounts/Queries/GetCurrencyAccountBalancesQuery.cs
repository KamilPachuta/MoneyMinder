using MediatR;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetBalancesQuery(Guid AccountId, Guid CurrencyAccountId) : IRequest<GetCurrencyAccountBalancesResponse>;