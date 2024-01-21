using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyMinder.Application.Accounts.Services;
using MoneyMinder.Domain.Repository;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinder.Infrastructure.EF.Postgres;
using MoneyMinder.Infrastructure.EF.ReadServices;
using MoneyMinder.Infrastructure.EF.Repositories;

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

        
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAccountReadService, AccountReadService>();

        return services;
    }
}