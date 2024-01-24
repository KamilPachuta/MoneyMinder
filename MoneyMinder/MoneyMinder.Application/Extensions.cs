using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MoneyMinder.Domain.Accounts;

namespace MoneyMinder.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();
        
        return services;
    }
}