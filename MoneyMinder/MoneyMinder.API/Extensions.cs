using MoneyMinder.Application;
using MoneyMinder.Domain;
using MoneyMinder.Infrastructure;
using Serilog;

namespace MoneyMinder.API;

public static class Extensions
{
    public static ConfigureHostBuilder AddSerilog(this ConfigureHostBuilder host)
    {
        host.UseSerilog((context, loggerConfig) => 
            loggerConfig.ReadFrom.Configuration(context.Configuration));
        
        return host;
    }
    
    public static IServiceCollection AddProject(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomain();
        services.AddApplication();
        services.AddInfrastructure(configuration);

        return services;
    }
}