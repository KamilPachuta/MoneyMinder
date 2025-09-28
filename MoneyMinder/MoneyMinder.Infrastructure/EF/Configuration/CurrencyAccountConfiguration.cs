using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Infrastructure.EF.Configuration;

public class CurrencyAccountConfiguration : 
    IEntityTypeConfiguration<CurrencyAccount>,
    IEntityTypeConfiguration<Balance>,
    IEntityTypeConfiguration<Income>,
    IEntityTypeConfiguration<Payment>,
    IEntityTypeConfiguration<Budget>,
    IEntityTypeConfiguration<Limit>
{
    public void Configure(EntityTypeBuilder<CurrencyAccount> builder)
    {
        builder.ToTable(TableNames.CurrencyAccounts);
        builder.HasKey(ca => ca.Id);

        builder
            .Property(ca => ca.Name)
            .HasConversion(n => n.Name, n => new(n))
            .IsRequired();

        builder
            .HasMany(ca => ca.Balances)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(ca => ca.Incomes)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(ca => ca.Payments)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(ca => ca.Budgets)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void Configure(EntityTypeBuilder<Balance> builder)
    {
        builder.ToTable(TableNames.Balances);
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Currency)
            .HasConversion(c => c.Currency, c => new(c))
            .IsRequired();

        builder
            .Property(b => b.Amount)
            .HasConversion(b => b.Value, b => new(b))
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.ToTable(TableNames.Incomes);
        builder.HasKey(i => i.Id);

        builder
            .Property(i => i.Name)
            .HasConversion(n => n.Name, n => new(n))
            .IsRequired();

        builder
            .Property(i => i.Date)
            .HasConversion(d => d.Date, d => new(d))
            .IsRequired();

        builder
            .Property(i => i.Currency)
            .HasConversion(c => c.Currency, c => new(c))
            .IsRequired();
        
        builder
            .Property(i => i.Amount)
            .HasConversion(a => a.Value, a => new(a))
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable(TableNames.Payments);
        builder.HasKey(p => p.Id);
        
        builder
            .Property(p => p.Name)
            .HasConversion(n => n.Name, n=> new(n))
            .IsRequired();
        
        builder
            .Property(p => p.Date)
            .HasConversion(d => d.Date, d => new(d))
            .IsRequired();

        builder
            .Property(p => p.Currency)
            .HasConversion(c => c.Currency, c => new(c))
            .IsRequired();
        
        builder
            .Property(i => i.Amount)
            .HasConversion(a => a.Value, a => new(a))
            .IsRequired();
        
        builder
            .Property(p => p.Category)
            .HasConversion(c => c.Category, c => new(c))
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable(TableNames.Budgets);
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Currency)
            .HasConversion(c => c.Currency, c => new(c))
            .IsRequired();
        
        builder
            .Property(b => b.Date)
            .HasConversion(d => d.Date, d => new(d))
            .IsRequired();
        
        builder
            .HasMany(b => b.Limits)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void Configure(EntityTypeBuilder<Limit> builder)
    {
        builder.ToTable(TableNames.Limits);
        builder.HasKey(e => e.Id);

        builder
            .Property(l => l.Category)
            .HasConversion(c => c.Category, c => new(c))
            .IsRequired();
        
        builder
            .Property(l => l.Amount)
            .HasConversion(a => a.Value, a => new(a))
            .IsRequired();
    }
}