using MediatR;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Application.SavingsAccounts.Queries;

public record GetSavingsReportQuery(Guid AccountId, IEnumerable<Guid> SavingsAccountIds, DateTime From, DateTime To) : IRequest<GetSavingsReportResponse>;