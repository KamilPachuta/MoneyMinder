using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.Configuration;

internal sealed class AccountConfiguration : 
    IEntityTypeConfiguration<Account>,
    IEntityTypeConfiguration<User>,
    IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(TableNames.Accounts);
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Email)
            .HasConversion(e => e.Value, e => new AccountEmail(e));

        builder
            .Property(a => a.PasswordHash)
            .HasConversion(ph => ph.Value, ph => AccountPasswordHash.Create(ph));

        builder
            .Property(a => a.Role)
            .HasConversion(r => r.Role, r => new AccountRole(r));



        builder
            .HasOne(a => a.User)
            .WithOne()
            .HasForeignKey<User>();

        builder
            .HasMany(a => a.CurrencyAccounts)
            .WithOne(ca => ca.Account);
        
        builder
            .HasMany(a => a.SavingsPortfolios)
            .WithOne(sp => sp.Account);

    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.Users);
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Name)
            .HasConversion(n => n.ToString(), n => UserName.Create(n));

        builder
            .Property(a => a.PhoneNumber)
            .HasConversion(pn => pn.ToString(), pn => UserPhoneNumber.Create(pn));

        builder
            .Property(a => a.BirthDate)
            .HasConversion(bd => bd.Date, bd => new UserBrithDate(bd));

        builder
            .HasOne(u => u.Address)
            .WithOne()
            .HasForeignKey<Address>();
    }

    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(TableNames.Addresses);
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Country)
            .HasConversion(c => c.Value, c => new AddressCountry(c));

        builder
            .Property(a => a.City)
            .HasConversion(c => c.Value, c => new AddressCity(c));

        builder
            .Property(a => a.PostalCode)
            .HasConversion(pc => pc.Value, pc => new AddressPostalCode(pc));

        builder
            .Property(a => a.Street)
            .HasConversion(s => s.Value, s => new AddressStreet(s));
    }
}