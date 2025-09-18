using MoneyMinder.Domain.Shared.UnitOfWork;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.EF.UnitOfWork;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly MoneyMinderDbContext _dbContext;

    public UnitOfWork(MoneyMinderDbContext dbContext)
        => _dbContext = dbContext;
    
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}