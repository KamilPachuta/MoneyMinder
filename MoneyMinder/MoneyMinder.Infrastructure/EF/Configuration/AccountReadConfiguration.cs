using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Infrastructure.EF.ReadModels.Accounts;

namespace MoneyMinder.Infrastructure.EF.Configuration;

public class AccountReadConfiguration : 
    IEntityTypeConfiguration<AccountReadModel>,
    IEntityTypeConfiguration<UserReadModel>,
    IEntityTypeConfiguration<AddressReadModel>//,
    //IEntityTypeConfiguration<NotificationReadModel>
{
    public void Configure(EntityTypeBuilder<AccountReadModel> builder)
    {
        builder.ToTable(TableNames.Accounts);
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Email);

        builder
            .Property(a => a.PasswordHash);

        builder
            .Property(a => a.Role);

        builder
            .HasOne(a => a.User)
            .WithOne()
            .HasForeignKey<UserReadModel>();

        /*builder
            .HasMany(a => a.CurrencyAccounts)
            .WithOne()
            .HasForeignKey(ca => ca.AccountId);*/
        
        /*builder
            .HasMany(a => a.SavingsPortfolios)
            .WithOne()
            .HasForeignKey(sp => sp.AccountId);*/
        
        /*builder
            .HasMany(a => a.Notifications)
            .WithOne()
            .HasForeignKey(n => n.AccountId);*/
    }

    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.ToTable(TableNames.Users);
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Name);
        
        builder
            .Property(u => u.PhoneNumber);

        builder
            .Property(u => u.Gender);
        
        builder
            .Property(u => u.BirthDate);
        
        builder
            .HasOne(u => u.Address)
            .WithOne()
            .HasForeignKey<AddressReadModel>();
    }

    public void Configure(EntityTypeBuilder<AddressReadModel> builder)
    {
        builder.ToTable(TableNames.Addresses);
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Country);

        builder
            .Property(a => a.City);

        builder
            .Property(a => a.PostalCode);

        builder
            .Property(a => a.Street);
        
    }

    /*public void Configure(EntityTypeBuilder<NotificationReadModel> builder)
    {
        builder.ToTable(TableNames.Notifications);
        builder.HasKey(n => n.Id);

        builder
            .Property(n => n.Title);

        builder
            .Property(n => n.Description);

        builder
            .Property(n => n.Date);
    }*/
}