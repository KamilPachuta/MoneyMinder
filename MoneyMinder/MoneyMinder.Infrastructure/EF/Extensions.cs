using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.SavingsAccounts;
using MoneyMinder.Domain.SavingsAccounts.Entities;
using MoneyMinder.Infrastructure.EF.Configuration;
using MoneyMinder.Infrastructure.EF.ReadModels.Accounts;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccounts;
using MoneyMinder.Infrastructure.EF.ReadModels.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF;

public static class Extensions
{
    public static ModelBuilder AddEFConfig(this ModelBuilder modelBuilder)
    {
        var accountConfiguration = new AccountConfiguration();
        modelBuilder.ApplyConfiguration<Account>(accountConfiguration);
        modelBuilder.ApplyConfiguration<User>(accountConfiguration);
        modelBuilder.ApplyConfiguration<Address>(accountConfiguration);

        var currencyAccountConfiguration = new CurrencyAccountConfiguration();
        modelBuilder.ApplyConfiguration<CurrencyAccount>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Balance>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Income>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Payment>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Budget>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Limit>(currencyAccountConfiguration);

        var savingsAccountConfiguration = new SavingsAccountConfiguration();
        modelBuilder.ApplyConfiguration<SavingsAccount>(savingsAccountConfiguration);
        modelBuilder.ApplyConfiguration<SavingsTransaction>(savingsAccountConfiguration);


        return modelBuilder;
    }
    
    public static ModelBuilder AddEFReadConfig(this ModelBuilder modelBuilder)
    {
        var accountReadConfiguration = new AccountReadConfiguration();
        modelBuilder.ApplyConfiguration<AccountReadModel>(accountReadConfiguration);
        modelBuilder.ApplyConfiguration<UserReadModel>(accountReadConfiguration);
        modelBuilder.ApplyConfiguration<AddressReadModel>(accountReadConfiguration);

        var currencyAccountReadConfiguration = new CurrencyAccountReadConfiguration();
        modelBuilder.ApplyConfiguration<CurrencyAccountReadModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<BalanceReadModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<IncomeReadModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<PaymentReadModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<BudgetReadModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<LimitReadModel>(currencyAccountReadConfiguration);
        
        var savingsAccountReadConfiguration = new SavingsAccountReadConfiguration();
        modelBuilder.ApplyConfiguration<SavingsAccountReadModel>(savingsAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<SavingsTransactionReadModel>(savingsAccountReadConfiguration);
        
        return modelBuilder;
    }
}