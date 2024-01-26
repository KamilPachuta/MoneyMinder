using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Domain.SavingsPortfolios;
using MoneyMinder.Domain.SavingsPortfolios.Entities;

namespace MoneyMinder.Infrastructure.EF.Configuration;

internal sealed class SavingsPortfolioConfiguration :
    IEntityTypeConfiguration<SavingsPortfolio>,
    IEntityTypeConfiguration<SavingsTransaction>
{
    public void Configure(EntityTypeBuilder<SavingsPortfolio> builder)
    {
        builder.ToTable(TableNames.SavingsPortfolios);
        builder.HasKey(sp => sp.Id);

        builder
            .Property(sp => sp.Name)
            .HasConversion(n => n.Name, n => new(n))
            .IsRequired();

        builder
            .Property(sp => sp.Currency)
            .IsRequired();

        builder
            .Property(sp => sp.PlannedAmount)
            .HasConversion(pa => pa.Amount, pa => new(pa))
            .IsRequired();
        
        builder
            .Property(sp => sp.ActualAmount)
            .HasConversion(aa => aa.Amount, aa => new(aa))
            .IsRequired();

        builder
            .HasMany(sp => sp.Transactions)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

    }

    public void Configure(EntityTypeBuilder<SavingsTransaction> builder)
    {
        builder.ToTable(TableNames.SavingsTransactions);
        builder.HasKey(st => st.Id);

        builder
            .Property(st => st.Name)
            .HasConversion(n => n.Name, n => new(n))
            .IsRequired();

        builder
            .Property(st => st.Date)
            .IsRequired();

        builder
            .Property(st => st.Currency)
            .IsRequired();

        builder
            .Property(st => st.Amount)
            .HasConversion(a => a.Value, a => new(a))
            .IsRequired();

        builder
            .Property(st => st.Type)
            .IsRequired();
    }
}