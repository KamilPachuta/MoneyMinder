using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountPaymentsReportHandler : IRequestHandler<GetCurrencyAccountPaymentsReportQuery, GetCurrencyAccountReportPaymentsResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountPaymentsReportHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetCurrencyAccountReportPaymentsResponse> Handle(GetCurrencyAccountPaymentsReportQuery request, CancellationToken cancellationToken)
    {
        var from =  DateTime.SpecifyKind(request.From, DateTimeKind.Utc);
        var to = DateTime.SpecifyKind(request.To, DateTimeKind.Utc);
        
        
        var result = _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId && request.CurrencyAccountIds.Contains(ca.Id))
            .SelectMany(ca => ca.Payments
                .Where(p =>
                    p.Date >= request.From &&
                    p.Date <= request.To &&
                    request.Currencies.Contains(p.Currency))
                .Select(p => new CurrencyPaymentDto()
                {
                    Date = p.Date,
                    Currency = (CurrencyDto)p.Currency,
                    Amount = p.Amount,
                    Category = (CategoryDto)p.Category
                })
                .OrderBy(t => t.Date))
            .ToList();
        
        return new GetCurrencyAccountReportPaymentsResponse(result);
    }
}


