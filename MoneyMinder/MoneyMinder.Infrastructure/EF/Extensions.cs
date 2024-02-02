using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.SavingsPortfolios;
using MoneyMinder.Domain.SavingsPortfolios.Entities;
using MoneyMinder.Infrastructure.EF.Configuration;
using MoneyMinder.Infrastructure.EF.ReadModels.Account;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;
using MoneyMinder.Infrastructure.EF.ReadModels.Savings;

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
        modelBuilder.ApplyConfiguration<Budget>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Expense>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Balance>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Income>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<Payment>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<MonthlyIncome>(currencyAccountConfiguration);
        modelBuilder.ApplyConfiguration<MonthlyPayment>(currencyAccountConfiguration);

        var savingsPortfolioConfiguration = new SavingsPortfolioConfiguration();
        modelBuilder.ApplyConfiguration<SavingsPortfolio>(savingsPortfolioConfiguration);
        modelBuilder.ApplyConfiguration<SavingsTransaction>(savingsPortfolioConfiguration);


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
        modelBuilder.ApplyConfiguration<MonthlyIncomeReadModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<MonthlyPaymentReadModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<BudgetReadModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<ExpenseReadModel>(currencyAccountReadConfiguration);
        
        var savingsPortfolioReadConfiguration = new SavingsPortfolioReadConfiguration();
        modelBuilder.ApplyConfiguration<SavingsPortfolioReadModel>(savingsPortfolioReadConfiguration);
        modelBuilder.ApplyConfiguration<SavingsTransactionReadModel>(savingsPortfolioReadConfiguration);
        

        return modelBuilder;
    }
}