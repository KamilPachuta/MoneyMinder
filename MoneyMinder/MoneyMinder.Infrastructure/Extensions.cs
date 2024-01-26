using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyMinder.Application.Accounts.Services;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Application.Savings.Services;
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


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICurrencyAccountRepository, CurrencyAccountRepository>();
        services.AddScoped<ISavingsPortfolioRepository, SavingsPortfolioRepository>();

        services.AddScoped<IAccountReadService, AccountReadService>();
        services.AddScoped<ICurrencyAccountReadService, CurrencyAccountReadService>();
        services.AddScoped<ISavingsPortfolioReadService, SavingsPortfolioReadService>();
        
        
        return services;
    }
}