using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.SavingsAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.SavingsAccounts;

internal sealed class GetAllTimeSavingsReportHandler : IRequestHandler<GetAllTimeSavingsReportQuery, GetSavingsReportResponse>
{
    private readonly MoneyMinderReadDbContext _context;
    
    public GetAllTimeSavingsReportHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }
    
    public async Task<GetSavingsReportResponse> Handle(GetAllTimeSavingsReportQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.SavingsAccounts
            .Where(sa =>
                sa.AccountId == request.AccountId &&
                request.SavingsAccountIds.Contains(sa.Id))
            .SelectMany(sa => sa.Transactions
                .Select(t => new SavingsTransactionDto()
                {
                    Currency = (CurrencyDto)t.Currency,
                    Amount = t.Amount,
                    Date = t.Date,
                    TransactionType = (TransactionTypeDto)t.Type
                })
                .OrderBy(t => t.Date))
            .ToListAsync();

        return new GetSavingsReportResponse(result);
    }
}