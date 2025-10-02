using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.Accounts;

public record GetUserNameResponse(string Name) : IResponse;