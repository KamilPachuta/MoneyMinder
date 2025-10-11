using MediatR;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountMonthPaymentsQuery(Guid AccountId, Guid CurrencyAccountId, DateTime Month) : IRequest<GetCurrencyAccountMonthPaymentsResponse>;