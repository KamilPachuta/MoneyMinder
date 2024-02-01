using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public record GetCurrencyAccountIdByNameResponse(Guid Id) : IResponse;