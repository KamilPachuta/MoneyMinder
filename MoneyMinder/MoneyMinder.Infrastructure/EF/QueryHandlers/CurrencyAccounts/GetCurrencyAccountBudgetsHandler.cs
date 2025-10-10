using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountBudgetsHandler : IRequestHandler<GetCurrencyAccountBudgetsQuery, GetCurrencyAccountBudgetsResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountBudgetsHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }
    
    public async Task<GetCurrencyAccountBudgetsResponse> Handle(GetCurrencyAccountBudgetsQuery request, CancellationToken cancellationToken)
    {
        var budgets = await _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId && ca.Id == request.CurrencyAccountId)
            .SelectMany(ca => 
                ca.Budgets.Select(b => new BudgetDto()
                {
                    Currency = (CurrencyDto)b.Currency,
                    Date = b.Date,
                    Limits = b.Limits.Select(limit => new LimitDto
                    {
                        CategoryDto = (CategoryDto)limit.Category,
                        Amount = limit.Amount
                    }).ToList()
                }))
            .ToListAsync(cancellationToken);
        
        return new GetCurrencyAccountBudgetsResponse(budgets);
    }
}