using System.Text;
using Microsoft.IdentityModel.Tokens;
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
        services.AddAuthenticationSettings(configuration);
        
        return services;
    }
    
    public static IServiceCollection AddAuthenticationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationSettings = new AuthenticationSettings();
        configuration.GetSection("Authentication").Bind(authenticationSettings);

        //Authentication
        services.AddSingleton(authenticationSettings);
        
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = "Bearer";
            option.DefaultScheme = "Bearer";
            option.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.JwtIssuer,
                ValidAudience = authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))

            };
        });
        
        return services;
    }
}