using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountsMetadataResponse(IEnumerable<CurrencyAccountMetadataDto> CurrencyAccountMetadataDtos) : IResponse;
