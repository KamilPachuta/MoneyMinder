using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.Configuration;

public class CurrencyAccountReadConfiguration : 
    IEntityTypeConfiguration<CurrencyAccountReadModel>,
    IEntityTypeConfiguration<BalanceReadModel>,
    IEntityTypeConfiguration<IncomeReadModel>,
    IEntityTypeConfiguration<PaymentReadModel>,
    IEntityTypeConfiguration<BudgetReadModel>,
    IEntityTypeConfiguration<LimitReadModel>
{
    public void Configure(EntityTypeBuilder<CurrencyAccountReadModel> builder)
    {
        builder.ToTable(TableNames.CurrencyAccounts);
        builder.HasKey(ca => ca.Id);

        builder.Property(ca => ca.Id);
        builder.Property(ca => ca.Name);

        builder
            .HasMany(ca => ca.Balances)
            .WithOne()
            .HasForeignKey(b => b.CurrencyAccountId);
        
        builder
            .HasMany(ca => ca.Incomes)
            .WithOne()
            .HasForeignKey(i => i.CurrencyAccountId);
        
        builder
            .HasMany(ca => ca.Payments)
            .WithOne()
            .HasForeignKey(p => p.CurrencyAccountId);

        builder
            .HasMany(ca => ca.Budgets)
            .WithOne()
            .HasForeignKey(b => b.CurrencyAccountId);
    }

    public void Configure(EntityTypeBuilder<BalanceReadModel> builder)
    {
        builder.ToTable(TableNames.Balances);
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id);
        builder.Property(b => b.Amount);
        builder.Property(b => b.Currency);
    }

    public void Configure(EntityTypeBuilder<IncomeReadModel> builder)
    {
        builder.ToTable(TableNames.Incomes);
        builder.HasKey(i => i.Id);
        

        builder.Property(i => i.Id);
        builder.Property(i => i.Name);
        builder.Property(i => i.Date);
        builder.Property(i => i.Currency);
        builder.Property(i => i.Amount);
    }

    public void Configure(EntityTypeBuilder<PaymentReadModel> builder)
    {
        builder.ToTable(TableNames.Payments);
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id);
        builder.Property(p => p.Name);
        builder.Property(p => p.Date);
        builder.Property(p => p.Currency);
        builder.Property(p => p.Amount);
        builder.Property(p => p.Category);
    }

    public void Configure(EntityTypeBuilder<BudgetReadModel> builder)
    {
        builder.ToTable(TableNames.Budgets);
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Id);
        builder.Property(b => b.Currency);
        builder.Property(b => b.Date);

        
        builder
            .HasMany(b => b.Limits)
            .WithOne()
            .HasForeignKey(l => l.BudgetId);
    }

    public void Configure(EntityTypeBuilder<LimitReadModel> builder)
    {
        builder.ToTable(TableNames.Limits);
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id);
        builder.Property(l => l.Category);
        builder.Property(l => l.Amount);
    }
}