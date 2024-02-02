using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.SavingsPortfolios;
using MoneyMinder.Infrastructure.EF.ReadModels.Account;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;
using MoneyMinder.Infrastructure.EF.ReadModels.Savings;

namespace MoneyMinder.Infrastructure.EF.Context;


internal sealed class MoneyMinderReadDbContext : DbContext
{
    public DbSet<AccountReadModel> Accounts { get; set; }
    public DbSet<CurrencyAccountReadModel> CurrencyAccounts { get; set; }
    public DbSet<SavingsPortfolioReadModel> SavingsPortfolios { get; set; }

    public MoneyMinderReadDbContext(DbContextOptions<MoneyMinderReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("MoneyMinderr");

        modelBuilder.AddEFReadConfig();
    }
}