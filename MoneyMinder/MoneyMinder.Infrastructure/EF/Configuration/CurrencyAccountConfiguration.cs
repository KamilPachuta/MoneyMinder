using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Infrastructure.EF.Configuration;

internal sealed class CurrencyAccountConfiguration : 
    IEntityTypeConfiguration<CurrencyAccount>,
    IEntityTypeConfiguration<Balance>,
    IEntityTypeConfiguration<Income>,
    IEntityTypeConfiguration<Payment>,
    IEntityTypeConfiguration<MonthlyIncome>,
    IEntityTypeConfiguration<MonthlyPayment>,
    IEntityTypeConfiguration<Budget>,
IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<CurrencyAccount> builder)
    {
        builder.ToTable(TableNames.CurrencyAccounts);
        builder.HasKey(ca => ca.Id);

        builder
            .Property(ca => ca.Name)
            .HasConversion(n => n.Name, n => new(n));

        builder
            .HasMany(ca => ca.Balances)
            .WithOne();
        
        builder
            .HasMany(ca => ca.Incomes)
            .WithOne();
        
        builder
            .HasMany(ca => ca.Payments)
            .WithOne();
        
        builder
            .HasMany(ca => ca.MonthlyIncomes)
            .WithOne();
        
        builder
            .HasMany(ca => ca.MonthlyPayments)
            .WithOne();
        
        builder
            .HasOne(ca => ca.Budget)
            .WithOne()
            .HasForeignKey<Budget>();
    }

    public void Configure(EntityTypeBuilder<Balance> builder)
    {
        builder.ToTable(TableNames.Balances);
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Amount)
            .HasConversion(b => b.Value, b => new(b));
    }

    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.ToTable(TableNames.Incomes);
        builder.HasKey(i => i.Id);

        builder
            .Property(i => i.Name)
            .HasConversion(n => n.Name, n=> new(n));

        builder
            .Property(i => i.Amount)
            .HasConversion(a => a.Value, a => new(a));
    }

    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable(TableNames.Payments);
        builder.HasKey(p => p.Id);
        
        builder
            .Property(p => p.Name)
            .HasConversion(n => n.Name, n=> new(n));

        builder
            .Property(i => i.Amount)
            .HasConversion(a => a.Value, a => new(a));
    }

    public void Configure(EntityTypeBuilder<MonthlyIncome> builder)
    {
        builder.ToTable(TableNames.MonthlyIncomes);
        builder.HasKey(mi => mi.Id);
        
        builder
            .Property(mi => mi.Name)
            .HasConversion(n => n.Name, n=> new(n));

        builder
            .Property(mi => mi.Month)
            .HasConversion(m => m.Date, m => new Month(m));

        builder
            .Property(mi => mi.Amount)
            .HasConversion(a => a.Value, a => new(a));
    }

    public void Configure(EntityTypeBuilder<MonthlyPayment> builder)
    {
        builder.ToTable(TableNames.MonthlyPayments);
        builder.HasKey(mp => mp.Id);
        
         
        builder
            .Property(mp => mp.Name)
            .HasConversion(n => n.Name, n=> new(n));

        builder
            .Property(mp => mp.Month)
            .HasConversion(m => m.Date, m => new Month(m));

        builder
            .Property(mp => mp.Amount)
            .HasConversion(a => a.Value, a => new(a));
    }

    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable(TableNames.Budgets);
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Name)
            .HasConversion(n => n.Name, n => new(n));

        builder
            .Property(b => b.ExpectedIncome)
            .HasConversion(pa => pa.Amount, pa => new(pa));

        builder
            .Property(b => b.Date)
            .HasConversion(d => d.Date, d => new(d));

        builder
            .HasMany(b => b.Expenses)
            .WithOne();

    }
    
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable(TableNames.Expenses);
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Amount)
            .HasConversion(a => a.Amount, a => new(a));
    }
}