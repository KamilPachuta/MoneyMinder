using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Endpoints.CurrencyAccount;
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
        
        commands.MapPost("/", CurrencyAccountEndpoints.PostCurrencyAccount);
        
        commands.MapPatch("/", CurrencyAccountEndpoints.PatchCurrencyAccount);
        
        commands.MapDelete("/", CurrencyAccountEndpoints.DeleteCurrencyAccount);
        
        
        commands.MapPost("/Income", CurrencyAccountEndpoints.IncomeAdd);
        
        commands.MapDelete("/Income", CurrencyAccountEndpoints.IncomeRemove);
        
        
        commands.MapPost("/Payment", CurrencyAccountEndpoints.PaymentAdd);
        
        commands.MapDelete("/Payment", CurrencyAccountEndpoints.PaymentRemove);


        commands.MapPost("/Budget", CurrencyAccountEndpoints.BudgetCreate);
        
        commands.MapPut("/Budget/Limit", CurrencyAccountEndpoints.LimitEdit);
        
        commands.MapDelete("/Budget", CurrencyAccountEndpoints.BudgetDelete);
        
        
        
        var queries = app.MapGroup("").AddFluentValidationAutoValidation();
        
        queries.MapGet("/Names", CurrencyAccountReadEndpoints.GetCurrencyAccountNames);
        
        queries.MapGet("/id/{name}", CurrencyAccountReadEndpoints.GetCurrencyAccountIdByName);
        
        queries.MapGet("/{id}/balances", CurrencyAccountReadEndpoints.GetCurrencyAccountBalances);
        
        queries.MapGet("/{id}/Transactions", CurrencyAccountReadEndpoints.GetCurrencyAccountTransactions);
        
    }
}