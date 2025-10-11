using MediatR;
using MoneyMinder.Domain.Shared.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountMonthPaymentsByCurrencyQuery(Guid AccountId, Guid CurrencyAccountId, DateTime Month, Currency Currency) 
    : IRequest<GetCurrencyAccountMonthPaymentsResponse>;