using Microsoft.Extensions.DependencyInjection;
using MoneyMinder.Domain.Shared.Factories;
using MoneyMinder.Domain.Shared.Factories.Interfaces;

namespace MoneyMinder.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IAccountFactory, AccountFactory>();
        /*services.AddSingleton<ICurrencyAccountFactory, CurrencyAccountFactory>();
        services.AddSingleton<ISavingsPortfolioFactory, SavingsPortfolioFactory>();*/

        return services;
    }
}