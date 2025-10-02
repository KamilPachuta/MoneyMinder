using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.SavingsAccounts;

public record GetSavingsAccountNamesResponse(IEnumerable<string> Names) : IResponse;
