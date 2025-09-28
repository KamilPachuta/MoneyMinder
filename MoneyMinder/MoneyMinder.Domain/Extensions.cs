using Microsoft.Extensions.DependencyInjection;
using MoneyMinder.Domain.Factories;
using MoneyMinder.Domain.Factories.Interfaces;


namespace MoneyMinder.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IAccountFactory, AccountFactory>();
        services.AddSingleton<ICurrencyAccountFactory, CurrencyAccountFactory>();
        services.AddSingleton<ISavingsAccountFactory, SavingsAccountFactory>();

        return services;
    }
}