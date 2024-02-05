using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Savings.Models;
using MoneyMinder.Application.Savings.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.Savings;

internal sealed class GetAllSavingsDetailsHandler : IRequestHandler<GetAllSavingsDetails, IEnumerable<SavingsPortfolioModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetAllSavingsDetailsHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<SavingsPortfolioModel>> Handle(GetAllSavingsDetails request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.SavingsPortfolios
            .Where(sp => sp.AccountId == request.Id)
            .ToListAsync(cancellationToken);

        return result.Adapt<IEnumerable<SavingsPortfolioModel>>();
    }
}