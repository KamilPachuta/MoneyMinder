using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Infrastructure.EF.ReadModels.Account;

namespace MoneyMinder.Infrastructure.EF.Configuration;

public class AccountReadConfiguration : 
    IEntityTypeConfiguration<AccountModel>,
    IEntityTypeConfiguration<UserModel>,
    IEntityTypeConfiguration<AddressModel>
{
    public void Configure(EntityTypeBuilder<AccountModel> builder)
    {
        builder.ToTable(TableNames.Accounts);
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Email);

        builder
            .Property(a => a.PasswordHash);

        builder
            .Property(a => a.Role);

        //
        //
        // builder
        //     .HasOne(a => a.User)
        //     .WithOne()
        //     .HasForeignKey<User>();
        //
        // builder
        //     .HasMany(a => a.CurrencyAccounts)
        //     .WithOne(ca => ca.Account);
        //
        // builder
        //     .HasMany(a => a.SavingsPortfolios)
        //     .WithOne(sp => sp.Account);
    }

    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        throw new NotImplementedException();
    }

    public void Configure(EntityTypeBuilder<AddressModel> builder)
    {
        throw new NotImplementedException();
    }
}