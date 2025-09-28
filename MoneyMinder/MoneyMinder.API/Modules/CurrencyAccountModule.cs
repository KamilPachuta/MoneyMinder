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
        var commands = app.MapGroup("").AddFluentValidationAutoValidation();
        
        commands.MapPut("/", CurrencyAccountEndpoints.Put);
        
        commands.MapPost("/", CurrencyAccountEndpoints.Post);
        
        commands.MapDelete("/", CurrencyAccountEndpoints.Delete);
        
        
        commands.MapPost("/Income", CurrencyAccountEndpoints.IncomeAdd);
        
        commands.MapDelete("/Income", CurrencyAccountEndpoints.IncomeRemove);
        
        
        commands.MapPost("/Payment/", CurrencyAccountEndpoints.PaymentAdd);
        
        commands.MapDelete("/payment/", CurrencyAccountEndpoints.PaymentRemove);
        
        
        
        
    }
}