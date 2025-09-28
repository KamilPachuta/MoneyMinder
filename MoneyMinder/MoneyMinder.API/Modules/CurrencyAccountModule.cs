using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Modules.Abstractions;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace MoneyMinder.API.Modules;

public class CurrencyAccountModule : BaseModule
{
    public CurrencyAccountModule()
        : base("/CurrencyAccount")
    {
        
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("").AddFluentValidationAutoValidation();
        
        group.MapPut("/", CurrencyAccountEndpoints.Put);
        
        group.MapPost("/", CurrencyAccountEndpoints.Post);
        
        group.MapDelete("/", CurrencyAccountEndpoints.Delete);
        
        
        group.MapPost("/Income", CurrencyAccountEndpoints.IncomeAdd);
        
        
    }
}