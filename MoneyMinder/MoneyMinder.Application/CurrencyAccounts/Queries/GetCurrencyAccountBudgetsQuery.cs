using MediatR;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountBudgetsQuery(Guid AccountId, Guid CurrencyAccountId) : IRequest<GetCurrencyAccountBudgetsResponse>;