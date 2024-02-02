using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetAllHandler : IRequestHandler<GetAll, IEnumerable<CurrencyAccountModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetAllHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<CurrencyAccountModel>> Handle(GetAll request, CancellationToken cancellationToken)
    {
        var result =  await _dbContext.CurrencyAccounts
            .Include(ca => ca.Budget)
            .Include(ca => ca.Balances)
            .Include(ca => ca.Incomes)
            .Include(ca => ca.Payments)
            .Include(ca => ca.MonthlyIncomes)
            .Include(ca => ca.MonthlyPayments)
            .ToListAsync();

        return result.Adapt<IEnumerable<CurrencyAccountModel>>();
    }
}