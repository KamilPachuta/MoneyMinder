using MediatR;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Application.SavingsAccounts.Queries;

public record GetAllTimeSavingsReportQuery(Guid AccountId, IEnumerable<Guid> SavingsAccountIds) : IRequest<GetSavingsReportResponse>;