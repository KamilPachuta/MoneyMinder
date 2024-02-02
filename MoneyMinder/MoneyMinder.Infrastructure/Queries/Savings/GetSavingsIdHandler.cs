using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Savings.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.Savings;

internal sealed class GetSavingsIdHandler : IRequestHandler<GetSavingsId, Guid>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetSavingsIdHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(GetSavingsId request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.SavingsPortfolios
            .FirstOrDefaultAsync(sp => sp.AccountId == request.AccountId && sp.Name == request.Name);

        if (result is null)
        {
            return Guid.Empty;
        }

        return result.Id;
    }
}