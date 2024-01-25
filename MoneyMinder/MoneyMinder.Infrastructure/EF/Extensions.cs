using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
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

        var currencyAccountConfiguration = new CurrencyAccountConfiguration();
        modelBuilder.ApplyConfiguration<CurrencyAccount>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Budget>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Expense>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Balance>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Income>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Payment>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<MonthlyIncome>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<MonthlyPayment>(currencyAccountConfiguration);


        return modelBuilder;
    }
}