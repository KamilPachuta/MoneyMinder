using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountBalancesResponse(IEnumerable<BalanceDto> Balances) : IResponse;