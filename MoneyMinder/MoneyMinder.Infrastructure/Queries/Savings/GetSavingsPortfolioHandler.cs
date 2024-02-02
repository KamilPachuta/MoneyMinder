using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Savings.Models;
using MoneyMinder.Application.Savings.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.Savings;

internal sealed class GetSavingsPortfolioHandler : IRequestHandler<GetSavingsPortfolio, SavingsPortfolioModel>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetSavingsPortfolioHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<SavingsPortfolioModel> Handle(GetSavingsPortfolio request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.SavingsPortfolios
            .Include(sp => sp.Transactions)
            .FirstOrDefaultAsync(sp => sp.Id == request.Id);
        result.Transactions = result.Transactions.OrderByDescending(t => t.Date).ToList();
        return result.Adapt<SavingsPortfolioModel>();

    }
}