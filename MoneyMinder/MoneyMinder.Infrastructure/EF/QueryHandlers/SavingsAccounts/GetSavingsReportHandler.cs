using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.SavingsAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.SavingsAccounts;

internal sealed class GetSavingsReportHandler : IRequestHandler<GetSavingsReportQuery, GetSavingsReportResponse>
{
    private readonly MoneyMinderReadDbContext _context; 
    
    public GetSavingsReportHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }


    public async Task<GetSavingsReportResponse> Handle(GetSavingsReportQuery request, CancellationToken cancellationToken)
    {
        var from =  DateTime.SpecifyKind(request.From, DateTimeKind.Utc);
        var to = DateTime.SpecifyKind(request.To, DateTimeKind.Utc);

        var result = await _context.SavingsAccounts
            .Where(sa =>
                sa.AccountId == request.AccountId &&
                request.SavingsAccountIds.Contains(sa.Id))
            .SelectMany(sa => sa.Transactions
                .Where(t =>
                    t.Date >= request.From &&
                    t.Date <= request.To)
                .Select(t => new SavingsTransactionDto()
                {
                    Currency = (CurrencyDto)t.Currency,
                    Amount = t.Amount,
                    Date = t.Date,
                    TransactionType = (TransactionTypeDto)t.Type
                })
                .OrderByDescending(t => t.Date))
            .ToListAsync();

        return new GetSavingsReportResponse(result);
    }
}