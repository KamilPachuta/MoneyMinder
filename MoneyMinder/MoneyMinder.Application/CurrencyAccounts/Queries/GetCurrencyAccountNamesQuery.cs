using MediatR;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountNamesQuery(Guid AccountId) : IRequest<GetCurrencyAccountNamesResponse>;