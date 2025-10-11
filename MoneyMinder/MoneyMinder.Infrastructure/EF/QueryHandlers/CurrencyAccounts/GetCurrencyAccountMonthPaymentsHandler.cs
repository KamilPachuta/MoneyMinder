using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountMonthPaymentsHandler : IRequestHandler<GetCurrencyAccountMonthPaymentsQuery, GetCurrencyAccountMonthPaymentsResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountMonthPaymentsHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetCurrencyAccountMonthPaymentsResponse> Handle(GetCurrencyAccountMonthPaymentsQuery request, CancellationToken cancellationToken)
    {
        var result = _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId && ca.Id == request.CurrencyAccountId)
            .SelectMany(ca => ca.Payments
                .Where(p => p.Date.Month == request.Month.Month && p.Date.Year == request.Month.Year)
                .Select(p => new CurrencyPaymentDto()
                {
                    Date = p.Date,
                    Currency = (CurrencyDto)p.Currency,
                    Amount = p.Amount,
                    Category = (CategoryDto)p.Category
                })
                .OrderByDescending(t => t.Date))
            .ToList();
        
        return new GetCurrencyAccountMonthPaymentsResponse(result);
    }
}