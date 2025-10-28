using MediatR;
using MoneyMinder.Domain.Shared.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountAllTimeBalanceReportQuery(Guid AccountId, 
    IEnumerable<Guid> CurrencyAccountIds, 
    IEnumerable<Currency> Currencies)
    : IRequest<GetCurrencyAccountBalanceReportResponse>;