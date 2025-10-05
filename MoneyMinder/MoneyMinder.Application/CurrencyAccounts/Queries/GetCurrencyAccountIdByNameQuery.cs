using MediatR;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountIdByNameQuery(Guid AccountId, string Name) : IRequest<GetCurrencyAccountIdByNameResponse>;