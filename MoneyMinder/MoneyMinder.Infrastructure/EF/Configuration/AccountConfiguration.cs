using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Infrastructure.EF.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(TableNames.Accounts);
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Email)
            .HasConversion(e => e.Value, e => new AccountEmail(e));

        builder
            .Property(a => a.PasswordHash)
            .HasConversion(ph => ph.Value, ph => AccountPasswordHash.Create(ph));

        builder
            .Property(a => a.Role)
            .HasConversion(r => r.Role, r => new AccountRole(r));


    }
}