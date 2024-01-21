using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.Accounts.ValueObjects;

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
    }

    public void Configure(EntityTypeBuilder<Address> builder)
    {
        throw new NotImplementedException();
    }
}