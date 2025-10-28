using MediatR;
using MoneyMinder.Domain.Shared.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountPaymentsReportQuery(
    Guid AccountId, 
    IEnumerable<Guid> CurrencyAccountIds, 
    DateTime From, 
    DateTime To, 
    IEnumerable<Currency> Currencies) 
    : IRequest<GetCurrencyAccountReportPaymentsResponse>;
