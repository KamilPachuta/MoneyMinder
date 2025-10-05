using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountTransactionsResponse(IEnumerable<CurrencyTransactionDto> Transactions) : IResponse;