using MediatR;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountTransactionsQuery(Guid AccountId, Guid CurrencyAccountId) : IRequest<GetCurrencyAccountTransactionsResponse>;
