using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountBalanceReportResponse(IEnumerable<CurrencyTransactionDto> Transactions) : IResponse;