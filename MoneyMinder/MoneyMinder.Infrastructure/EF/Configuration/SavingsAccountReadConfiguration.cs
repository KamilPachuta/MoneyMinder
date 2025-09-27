using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Infrastructure.EF.ReadModels.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF.Configuration;

public class SavingsAccountReadConfiguration:
    IEntityTypeConfiguration<SavingsAccountReadModel>,
    IEntityTypeConfiguration<SavingsTransactionReadModel>
{
    public void Configure(EntityTypeBuilder<SavingsAccountReadModel> builder)
    {
        builder.ToTable(TableNames.SavingsAccounts);
        builder.HasKey(sa => sa.Id);

        builder
            .Property(sa => sa.Name);

        builder
            .Property(sa => sa.Currency);

        builder
            .Property(sa => sa.PlannedAmount);

        builder
            .Property(sa => sa.CurrentAmount);

        builder
            .HasMany(sa => sa.Transactions)
            .WithOne()
            .HasForeignKey(st => st.SavingsAccountId);
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