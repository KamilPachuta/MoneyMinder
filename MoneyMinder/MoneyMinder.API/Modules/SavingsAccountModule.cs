using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Endpoints.SavingsAccount;
using MoneyMinder.API.Modules.Abstractions;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace MoneyMinder.API.Modules;

public class SavingsAccountModule : BaseModule
{
    public SavingsAccountModule() 
        : base("/SavingsAccount")
    {
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var commands = app.MapGroup("").AddFluentValidationAutoValidation();
        
        commands.MapPost("/", SavingsAccountEndpoints.PostSavingsAccount);
        
        commands.MapDelete("/", SavingsAccountEndpoints.DeleteSavingsAccount);
        
        commands.MapPatch("/Name/", SavingsAccountEndpoints.PatchSavingsAccountName);
        
        commands.MapPatch("/PlannedAmount/", SavingsAccountEndpoints.PatchSavingsAccountPlannedAmount);
        
        
        commands.MapPost("/Transaction/", SavingsAccountEndpoints.PostSavingsTransaction);
        
        
        var queries = app.MapGroup("").AddFluentValidationAutoValidation();
        
        queries.MapGet("/Names", SavingsAccountReadEndpoints.GetSavingsAccountNames);
        
        queries.MapGet("/Details", SavingsAccountReadEndpoints.GetSavingsAccountsDetails);
        
        
    }
    
}