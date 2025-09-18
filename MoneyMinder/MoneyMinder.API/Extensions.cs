using System.Text;
using Carter;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using MoneyMinder.API.Services;
using MoneyMinder.Application;
using MoneyMinder.Application.Behaviors;
using MoneyMinder.Domain;
using MoneyMinder.Infrastructure;

namespace MoneyMinder.API;

public static class Extensions
{
    public static IServiceCollection AddProject(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomain();
        services.AddApplication();
        services.AddInfrastructure(configuration);
        services.AddApi(configuration);
        
        
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
    
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            cfg.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });
        
        
        services.AddAuthenticationSettings(configuration);

        services.AddAuthorization();
        
        services.AddHttpContextAccessor();

        services.AddScoped<IUserService, UserService>();
        
        services.AddValidatorsFromAssembly(typeof(Extensions).Assembly);
        
        return services;
    }
}