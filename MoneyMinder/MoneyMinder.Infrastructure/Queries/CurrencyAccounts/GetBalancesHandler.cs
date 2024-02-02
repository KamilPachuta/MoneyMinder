using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetBalancesHandler : IRequestHandler<GetBalances, IEnumerable<BalanceModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetBalancesHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<BalanceModel>> Handle(GetBalances request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.CurrencyAccounts
            .Include(ca => ca.Balances)
            .FirstOrDefaultAsync(ca => ca.Id == request.Id);

        return result.Balances.Adapt<IEnumerable<BalanceModel>>();
    }
}