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
        builder.HasKey(sp => sp.Id);

        builder
            .Property(sp => sp.Name);

        builder
            .Property(sp => sp.Currency);

        builder
            .Property(sp => sp.PlannedAmount);

        builder
            .Property(sp => sp.CurrentAmount);

        builder
            .HasMany(sp => sp.Transactions)
            .WithOne()
            .HasForeignKey(st => st.SavingsAccountId);
    }
    
    public void Configure(EntityTypeBuilder<SavingsTransactionReadModel> builder)
    {
        throw new NotImplementedException();
    }
}