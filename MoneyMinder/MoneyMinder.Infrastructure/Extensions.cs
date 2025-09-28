using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyMinder.Application.Accounts.Services;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repositories;
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
        services.AddScoped<ISavingsAccountRepository, SavingsAccountRepository>();

        services.AddScoped<IAccountReadService, AccountReadService>();
        services.AddScoped<ICurrencyAccountReadService, CurrencyAccountReadService>();
        //services.AddScoped<ISavingsAccountReadService, SavingsAccountReadService>();
        
        //AddAdapters();
        
        return services;
    }



    /*public static void AddAdapters()
    {
        TypeAdapterConfig<MonthlyIncome, MonthlyTransactionModel>
            .NewConfig()
            .Map(dest => dest.Month, src => src.Month.Date);
        
        TypeAdapterConfig<AccountReadModel, PersonalInfoModel>
            .NewConfig()
            .Map(dest => dest.Name, src => src.User.Name)
            .Map(dest => dest.Name, src => src.User.PhoneNumber.ToString())
            .Map(dest => dest.Name, src => src.User.BirthDate)
            .Map(dest => dest.Name, src => src.User.Gender)
            .Map(dest => dest.Name, src => src.User.Address.Country.ToString())
            .Map(dest => dest.Name, src => src.User.Address.City)
            .Map(dest => dest.Name, src => src.User.Address.PostalCode)
            .Map(dest => dest.Name, src => src.User.Address.Street);
    }*/
}