using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.SavingsAccounts;

public record GetSavingsAccountDetailsResponse(
    Guid Id, 
    string Name, 
    CurrencyDto Currency,
    decimal CurrentAmount, 
    decimal PlannedAmount, 
    IEnumerable<SavingsTransactionDto> Transactions) 
    : IResponse;

