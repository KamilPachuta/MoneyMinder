using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountBalanceReportHandler : IRequestHandler<GetCurrencyAccountBalanceReportQuery, GetCurrencyAccountBalanceReportResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountBalanceReportHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetCurrencyAccountBalanceReportResponse> Handle(GetCurrencyAccountBalanceReportQuery request, CancellationToken cancellationToken)
    {
        var from =  DateTime.SpecifyKind(request.From, DateTimeKind.Utc);
        var to = DateTime.SpecifyKind(request.To, DateTimeKind.Utc);

        var transactions = await _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId)
            .SelectMany(ca => 
                ca.Incomes
                    .Where(i => 
                        i.Date >= request.From && 
                        i.Date <= request.To &&
                        request.Currencies.Contains(i.Currency))
                    .Select(i => new CurrencyTransactionDto()
                    {
                        Date = i.Date,
                        Currency = (CurrencyDto)i.Currency,
                        Amount = i.Amount,
                        Category = null
                    })
                    .Concat(
                        ca.Payments
                            .Where(p => 
                                p.Date >= request.From && 
                                p.Date <= request.To &&
                                request.Currencies.Contains(p.Currency))
                            .Select(p => new CurrencyTransactionDto
                        {
                            Date = p.Date,
                            Currency = (CurrencyDto)p.Currency,
                            Amount = p.Amount,
                            Category = (CategoryDto)p.Category
                        })
                    )
            )
            .OrderByDescending(t => t.Date)
            .ToListAsync(cancellationToken);
        
        return new GetCurrencyAccountBalanceReportResponse(transactions);
    }
}