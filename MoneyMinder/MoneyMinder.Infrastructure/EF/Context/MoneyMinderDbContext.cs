using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.SavingsPortfolios;

namespace MoneyMinder.Infrastructure.EF.Context;

internal sealed class MoneyMinderDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CurrencyAccount> CurrencyAccounts { get; set; }
    public DbSet<SavingsPortfolio> SavingsPortfolios { get; set; }

    public MoneyMinderDbContext(DbContextOptions<MoneyMinderDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("MoneyMinderr");

        modelBuilder.AddEFConfig();
    }
}