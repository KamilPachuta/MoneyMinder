using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Savings.Models;
using MoneyMinder.Application.Savings.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.Savings;

internal sealed class GetSavingsNamesHandler : IRequestHandler<GetSavingsNames, IEnumerable<SavingsPortfolioNameModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetSavingsNamesHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<SavingsPortfolioNameModel>> Handle(GetSavingsNames request, CancellationToken cancellationToken)
        => await _dbContext.SavingsPortfolios
            .AsNoTracking()
            .Where(sp => sp.AccountId == request.Id)
            .Select(sp => new SavingsPortfolioNameModel(sp.Id, sp.Name))
            .ToListAsync();
    
}