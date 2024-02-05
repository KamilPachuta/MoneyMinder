using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetBudgetDetailsHandler : IRequestHandler<GetBudgetDetails, BudgetModel>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetBudgetDetailsHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<BudgetModel> Handle(GetBudgetDetails request, CancellationToken cancellationToken)
    {
        var ca = await _dbContext.CurrencyAccounts
            .Include(ca => ca.Budget)
            .ThenInclude(b => b.Expenses)
            .FirstOrDefaultAsync(ca => ca.Id == request.Id);

        return ca.Budget.Adapt<BudgetModel>();
    }
}