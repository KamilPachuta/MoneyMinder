using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.SavingsAccounts;

public record GetSavingsReportResponse(IEnumerable<SavingsTransactionDto> Transactions) : IResponse;