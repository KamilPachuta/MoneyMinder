using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.SavingsAccounts;

public record GetSavingsAccountsMetadataResponse(IEnumerable<SavingsAccountMetadataDto> MetadataDtos) : IResponse;
