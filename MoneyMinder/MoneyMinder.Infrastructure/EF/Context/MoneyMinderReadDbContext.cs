using Microsoft.EntityFrameworkCore;
using MoneyMinder.Infrastructure.EF.ReadModels.Accounts;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccounts;
using MoneyMinder.Infrastructure.EF.ReadModels.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF.Context;

internal sealed class MoneyMinderReadDbContext : DbContext
{
    public DbSet<AccountReadModel> Accounts { get; set; }
    public DbSet<CurrencyAccountReadModel> CurrencyAccounts { get; set; }
    public DbSet<SavingsAccountReadModel> SavingsAccounts { get; set; }

    public MoneyMinderReadDbContext(DbContextOptions<MoneyMinderReadDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("MoneyMinder");

        modelBuilder.AddEFReadConfig();
    }
    
    public override int SaveChanges()
        => throw new InvalidOperationException("MoneyMinderReadDbContext is read-only.");

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => throw new InvalidOperationException("MoneyMinderReadDbContext is read-only.");
}