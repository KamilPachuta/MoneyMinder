using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetCurrencyAccountMonthIncomesHandler : IRequestHandler<GetCurrencyAccountMonthIncomes, IEnumerable<TransactionModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetCurrencyAccountMonthIncomesHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<TransactionModel>> Handle(GetCurrencyAccountMonthIncomes request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.CurrencyAccounts
            .FirstOrDefaultAsync(ca => ca.Id == request.Id);

        return result.Incomes?.Adapt<IEnumerable<TransactionModel>>();
    }
    
}