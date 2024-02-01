using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.SavingsPortfolios;
using MoneyMinder.Domain.SavingsPortfolios.Entities;
using MoneyMinder.Infrastructure.EF.Configuration;

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
        //var accountReadConfiguration = new AccountReadConfiguration();
        

        var currencyAccountReadConfiguration = new CurrencyAccountReadConfiguration();
        modelBuilder.ApplyConfiguration<CurrencyAccountModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<BalanceModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<IncomeModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<PaymentModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<MonthlyIncomeModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<MonthlyPaymentModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<BudgetModel>(currencyAccountReadConfiguration);
        modelBuilder.ApplyConfiguration<ExpenseModel>(currencyAccountReadConfiguration);
        
        //var savingsPortfolioReadConfiguration = new SavingsPortfolioReadConfiguration();


        return modelBuilder;
    }
}