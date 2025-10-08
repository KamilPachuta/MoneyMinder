using MediatR;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountDetailsQuery(Guid AccountId, string Name) : IRequest<GetCurrencyAccountDetailsResponse>;