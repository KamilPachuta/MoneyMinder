using System.Reflection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyMinder.Application.Accounts.Services;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Application.Savings.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repository;
using MoneyMinder.Domain.UnitOfWork;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinder.Infrastructure.EF.Postgres;
using MoneyMinder.Infrastructure.EF.ReadServices;
using MoneyMinder.Infrastructure.EF.Repositories;
using MoneyMinder.Infrastructure.EF.UnitOfWork;

namespace MoneyMinder.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresOptions = new PostgresOptions();
        configuration.GetSection("Postgres").Bind(postgresOptions);

        //DbContext
        services.AddDbContext<MoneyMinderDbContext>(ctx =>
            ctx.UseNpgsql(postgresOptions.MoneyMinderConnection));
        
        services.AddDbContext<MoneyMinderReadDbContext>(ctx =>
            ctx.UseNpgsql(postgresOptions.MoneyMinderConnection));


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICurrencyAccountRepository, CurrencyAccountRepository>();
        services.AddScoped<ISavingsPortfolioRepository, SavingsPortfolioRepository>();

        services.AddScoped<IAccountReadService, AccountReadService>();
        services.AddScoped<ICurrencyAccountReadService, CurrencyAccountReadService>();
        services.AddScoped<ISavingsPortfolioReadService, SavingsPortfolioReadService>();
        
        AddAdapters();
        
        return services;
    }



    public static void AddAdapters()
    {
        TypeAdapterConfig<MonthlyIncome, MonthlyTransactionModel>
            .NewConfig()
            .Map(dest => dest.Month, src => src.Month.Date);
    }
    // TypeAdapterConfig<IEnumerable<MonthlyIncome>, IEnumerable<MonthlyTransactionModel>>
        //     .NewConfig()
        //     .Map(dest => dest, src => 
        //         src.Select(income => new MonthlyTransactionModel(
        //             income.Id,
        //             income.Name,
        //     income.Month.Date,
        //     income.Currency,
        //     income.Amount,
        //     null // Tutaj możesz dodać logikę do ustawienia właściwości Category
        // ))
            
        // TypeAdapterConfig<IEnumerable<MonthlyIncome>, IEnumerable<MonthlyTransactionModel>>
        //     .NewConfig()
        //     .Map(dest => dest, src =>
        //         src.Select(income => new MonthlyTransactionModel(
        //             income.Id,
        //             income.Name,
        //             income.Month.Date,
        //             income.Currency,
        //             income.Amount,
        //             null // Tutaj możesz dodać logikę do ustawienia właściwości Category
        //         ))
    // );
    // {
            //     var dest = new List<MonthlyTransactionModel>();
            //     
            //     foreach (var income in src)
            //     {
            //         dest.Add(new (income.Id, income.Name, income.Month.Date, income.Currency, income.Amount, null));
            //     }
            //
            //     return dest.AsEnumerable();
            // });

        //TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    //}
}