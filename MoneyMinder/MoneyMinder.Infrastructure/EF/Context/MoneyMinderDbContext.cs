using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Accounts;

namespace MoneyMinder.Infrastructure.EF.Context;

internal sealed class MoneyMinderDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public MoneyMinderDbContext(DbContextOptions<MoneyMinderDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("MoneyMinderr");
        base.OnModelCreating(modelBuilder);
    }
}