using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountReportPaymentsResponse(IEnumerable<CurrencyPaymentDto> Payments) : IResponse;
