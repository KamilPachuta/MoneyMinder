using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Domain.SavingsAccounts;
using MoneyMinder.Domain.SavingsAccounts.Entities;

namespace MoneyMinder.Infrastructure.EF.Configuration;

internal sealed class SavingsAccountConfiguration :
    IEntityTypeConfiguration<SavingsAccount>,
    IEntityTypeConfiguration<SavingsTransaction>
{
    public void Configure(EntityTypeBuilder<SavingsAccount> builder)
    {
        builder.ToTable(TableNames.SavingsAccounts);
        builder.HasKey(sp => sp.Id);

        builder
            .Property(sa => sa.Name)
            .HasConversion(n => n.Name, n => new(n))
            .IsRequired();

        builder
            .Property(sa => sa.Currency)
            .HasConversion(c => c.Currency, c => new(c))
            .IsRequired();

        builder
            .Property(sa => sa.PlannedAmount)
            .HasConversion(pa => pa.Value, pa => new(pa))
            .IsRequired();
        
        builder
            .Property(sa => sa.CurrentAmount)
            .HasConversion(ca => ca.Value, ca => new(ca))
            .IsRequired();

        builder
            .HasMany(sa => sa.Transactions)
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
            .HasConversion(td => td.Date, td => new(td))
            .IsRequired();

        builder
            .Property(st => st.Currency)
            .HasConversion(c => c.Currency, c => new(c))
            .IsRequired();

        builder
            .Property(st => st.Amount)
            .HasConversion(a => a.Value, a => new(a))
            .IsRequired();

        builder
            .Property(st => st.Type)
            .HasConversion(tt => tt.TransactionType, tt => new(tt))
            .IsRequired();
    }
}