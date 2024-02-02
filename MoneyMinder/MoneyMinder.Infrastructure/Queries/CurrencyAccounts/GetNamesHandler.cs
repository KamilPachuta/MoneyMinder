using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetNamesHandler : IRequestHandler<GetNames, IEnumerable<CurrencyAccountNameModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetNamesHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<CurrencyAccountNameModel>> Handle(GetNames request, CancellationToken cancellationToken)
        => await _dbContext.CurrencyAccounts
            .AsNoTracking()
            .Where(ca => ca.AccountId == request.Id)
            .Select(ca => new CurrencyAccountNameModel(ca.Id, ca.Name))
            .ToListAsync();

}