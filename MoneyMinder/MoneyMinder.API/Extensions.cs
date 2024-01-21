using MoneyMinder.Domain;
using MoneyMinder.Infrastructure;

namespace MoneyMinder.API;

public static class Extensions
{
    public static IServiceCollection AddProject(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomain();
        services.AddInfrastructure(configuration);

        return services;
    }
}