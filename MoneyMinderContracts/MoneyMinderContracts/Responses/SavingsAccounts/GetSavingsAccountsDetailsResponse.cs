using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.SavingsAccounts;

public record GetSavingsAccountsDetailsResponse(IEnumerable<SavingsAccountDetailsDto> SavingsAccounts) : IResponse;