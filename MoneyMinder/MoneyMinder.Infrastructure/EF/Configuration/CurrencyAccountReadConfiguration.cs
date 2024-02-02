using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;


namespace MoneyMinder.Infrastructure.EF.Configuration;





internal sealed class CurrencyAccountReadConfiguration : 
    IEntityTypeConfiguration<CurrencyAccountReadModel>,
    IEntityTypeConfiguration<BalanceReadModel>,
    IEntityTypeConfiguration<IncomeReadModel>,
    IEntityTypeConfiguration<PaymentReadModel>,
    IEntityTypeConfiguration<MonthlyIncomeReadModel>,
    IEntityTypeConfiguration<MonthlyPaymentReadModel>,
    IEntityTypeConfiguration<BudgetReadModel>,
IEntityTypeConfiguration<ExpenseReadModel>
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
            .HasForeignKey(b => b.CurrencyAccountId);
        
        builder
            .HasMany(ca => ca.Payments)
            .WithOne()
            .HasForeignKey(b => b.CurrencyAccountId);
        
        builder
            .HasMany(ca => ca.MonthlyIncomes)
            .WithOne()
            .HasForeignKey(b => b.CurrencyAccountId);
        
        builder
            .HasMany(ca => ca.MonthlyPayments)
            .WithOne()
            .HasForeignKey(b => b.CurrencyAccountId);

        builder
            .HasOne(ca => ca.Budget)
            .WithOne()
            .HasForeignKey<BudgetReadModel>();
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

        builder.Property(t => t.Id);
        builder.Property(t => t.Name);
        builder.Property(t => t.Date);
        builder.Property(t => t.Currency);
        builder.Property(t => t.Amount);


    }

    public void Configure(EntityTypeBuilder<PaymentReadModel> builder)
    {
        builder.ToTable(TableNames.Payments);
        builder.HasKey(p => p.Id);
        
        builder.Property(t => t.Id);
        builder.Property(t => t.Name);
        builder.Property(t => t.Date);
        builder.Property(t => t.Currency);
        builder.Property(t => t.Amount);
    }

    public void Configure(EntityTypeBuilder<MonthlyIncomeReadModel> builder)
    {
        builder.ToTable(TableNames.MonthlyIncomes);
        builder.HasKey(mi => mi.Id);
        
        builder.Property(t => t.Id);
        builder.Property(t => t.Name);
        builder.Property(t => t.Month);
        builder.Property(t => t.Currency);
        builder.Property(t => t.Amount);
    }

    public void Configure(EntityTypeBuilder<MonthlyPaymentReadModel> builder)
    {
        builder.ToTable(TableNames.MonthlyPayments);
        builder.HasKey(mp => mp.Id);
        
        builder.Property(t => t.Id);
        builder.Property(t => t.Name);
        builder.Property(t => t.Month);
        builder.Property(t => t.Currency);
        builder.Property(t => t.Amount);
    }

    public void Configure(EntityTypeBuilder<BudgetReadModel> builder)
    {
        builder.ToTable(TableNames.Budgets);
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Id);
        builder.Property(b => b.Name);
        builder.Property(b => b.ExpectedIncome);
        builder.Property(b => b.Currency);
        builder.Property(b => b.Date);

        
        builder
            .HasMany(b => b.Expenses)
            .WithOne()
            .HasForeignKey(b => b.BudgetId);

    }
    
    public void Configure(EntityTypeBuilder<ExpenseReadModel> builder)
    {
        builder.ToTable(TableNames.Expenses);
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id);
        builder.Property(e => e.Category);
        builder.Property(e => e.Amount);
    }
}

    
