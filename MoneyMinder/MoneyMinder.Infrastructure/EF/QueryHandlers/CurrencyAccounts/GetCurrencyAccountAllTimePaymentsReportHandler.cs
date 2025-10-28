using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountAllTimePaymentsReportHandler : IRequestHandler<GetCurrencyAccountAllTimePaymentsReportQuery, GetCurrencyAccountReportPaymentsResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountAllTimePaymentsReportHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetCurrencyAccountReportPaymentsResponse> Handle(GetCurrencyAccountAllTimePaymentsReportQuery request, CancellationToken cancellationToken)
    {
        var result = _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId && request.CurrencyAccountIds.Contains(ca.Id))
            .SelectMany(ca => ca.Payments
                .Where(p => request.Currencies.Contains(p.Currency))
                .Select(p => new CurrencyPaymentDto()
                {
                    Date = p.Date,
                    Currency = (CurrencyDto)p.Currency,
                    Amount = p.Amount,
                    Category = (CategoryDto)p.Category
                })
                .OrderByDescending(t => t.Date))
            .ToList();
        
        return new GetCurrencyAccountReportPaymentsResponse(result);
    }
}