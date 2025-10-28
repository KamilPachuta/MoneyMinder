using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountAllTimeBalanceReportHandler : IRequestHandler<GetCurrencyAccountAllTimeBalanceReportQuery, GetCurrencyAccountBalanceReportResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountAllTimeBalanceReportHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetCurrencyAccountBalanceReportResponse> Handle(GetCurrencyAccountAllTimeBalanceReportQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId)
            .SelectMany(ca => 
                ca.Incomes
                    .Where(i => request.Currencies.Contains(i.Currency))
                    .Select(i => new CurrencyTransactionDto()
                    {
                        Date = i.Date,
                        Currency = (CurrencyDto)i.Currency,
                        Amount = i.Amount,
                        Category = null
                    })
                    .Concat(
                        ca.Payments
                            .Where(p => request.Currencies.Contains(p.Currency))
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