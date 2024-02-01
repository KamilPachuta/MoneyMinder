using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetAllHandler : IRequestHandler<GetAll, IEnumerable<CurrencyAccountModel>>
{
    private readonly DbSet<CurrencyAccount> _currencyAccounts; 

    public GetAllHandler(MoneyMinderDbContext dbContext)
    {
        _currencyAccounts = dbContext.CurrencyAccounts;
    }
    
    public async Task<IEnumerable<CurrencyAccountModel>> Handle(GetAll request, CancellationToken cancellationToken)
    {
        var result =  await _currencyAccounts
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