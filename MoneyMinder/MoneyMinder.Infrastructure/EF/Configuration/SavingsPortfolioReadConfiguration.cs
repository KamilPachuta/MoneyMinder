using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Infrastructure.EF.ReadModels.Savings;

namespace MoneyMinder.Infrastructure.EF.Configuration;

internal sealed class SavingsPortfolioReadConfiguration :
    IEntityTypeConfiguration<SavingsPortfolioReadModel>,
    IEntityTypeConfiguration<SavingsTransactionReadModel>
{
    public void Configure(EntityTypeBuilder<SavingsPortfolioReadModel> builder)
    {
        builder.ToTable(TableNames.SavingsPortfolios);
        builder.HasKey(sp => sp.Id);

        builder
            .Property(sp => sp.Name);

        builder
            .Property(sp => sp.Currency);

        builder
            .Property(sp => sp.PlannedAmount);

        builder
            .Property(sp => sp.ActualAmount);

        builder
            .HasMany(sp => sp.Transactions)
            .WithOne()
            .HasForeignKey(st => st.SavingsPortfolioId);
    }

    public void Configure(EntityTypeBuilder<SavingsTransactionReadModel> builder)
    {
        builder.ToTable(TableNames.SavingsTransactions);
        builder.HasKey(st => st.Id);

        builder
            .Property(st => st.Name);

        builder
            .Property(st => st.Date);

        builder
            .Property(st => st.Currency);

        builder
            .Property(st => st.Amount);

        builder
            .Property(st => st.Type);
    }
}