using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountMetadataByNameResponse(Guid Id, DateTime CreatedAt) : IResponse;