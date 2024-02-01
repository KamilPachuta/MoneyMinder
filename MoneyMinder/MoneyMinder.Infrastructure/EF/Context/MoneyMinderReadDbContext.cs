using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.SavingsPortfolios;

namespace MoneyMinder.Infrastructure.EF.Context;


internal sealed class MoneyMinderReadDbContext : DbContext
{
    //public DbSet<AccountModel> Accounts { get; set; }
    public DbSet<CurrencyAccountModel> CurrencyAccounts { get; set; }
   // public DbSet<SavingsPortfolioModel> SavingsPortfolios { get; set; }

    public MoneyMinderReadDbContext(DbContextOptions<MoneyMinderReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("MoneyMinderr");

        modelBuilder.AddEFReadConfig();
    }
}