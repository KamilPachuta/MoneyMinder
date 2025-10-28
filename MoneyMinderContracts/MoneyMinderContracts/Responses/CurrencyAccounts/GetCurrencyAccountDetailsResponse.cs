using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountDetailsResponse(
    Guid Id,
    DateTime CreatedAt,
    string Name, 
    IEnumerable<BalanceDto> Balances, 
    IEnumerable<CurrencyTransactionDetailsDto> Transactions) 
    : IResponse;
