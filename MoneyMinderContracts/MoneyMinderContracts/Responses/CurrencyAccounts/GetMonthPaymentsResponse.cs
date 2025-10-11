using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountMonthPaymentsResponse(IEnumerable<CurrencyPaymentDto> Payments) : IResponse;