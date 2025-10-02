using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.Accounts;

public record LoginResponse(string Token) : IResponse;
