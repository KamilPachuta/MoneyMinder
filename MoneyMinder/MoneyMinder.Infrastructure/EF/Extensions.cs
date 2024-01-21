using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Infrastructure.EF.Configuration;

namespace MoneyMinder.Infrastructure.EF;

public static class Extensions
{
    public static ModelBuilder AddEFConfig(this ModelBuilder modelBuilder)
    {
        var accountWriteConfiguration = new AccountConfiguration();
        modelBuilder.ApplyConfiguration<Account>(accountWriteConfiguration);
        modelBuilder.ApplyConfiguration<User>(accountWriteConfiguration);
        modelBuilder.ApplyConfiguration<Address>(accountWriteConfiguration);

        return modelBuilder;
    }
}