using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountDetailsResponse(
    Guid Id, 
    string Name, 
    IEnumerable<BalanceDto> Balances, 
    IEnumerable<CurrencyTransactionDto> Transactions) 
    : IResponse;
