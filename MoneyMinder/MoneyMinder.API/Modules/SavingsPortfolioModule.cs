using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Modules.Abstractions;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace MoneyMinder.API.Modules;

public class SavingsPortfolioModule : BaseModule
{
    public SavingsPortfolioModule() 
        : base("/Savings")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("").AddFluentValidationAutoValidation();

        
        group.MapPut("/", SavingsPortfolioEndpoints.Put);

        group.MapDelete("/", SavingsPortfolioEndpoints.Delete);
        
        group.MapPost("/Name/", SavingsPortfolioEndpoints.PostName);

        group.MapPost("/PlannedAmount/", SavingsPortfolioEndpoints.PostAmount);

        group.MapPost("/transaction/", SavingsPortfolioEndpoints.PostTransaction);

        
        var queries = app.MapGroup("").AddFluentValidationAutoValidation();

        queries.MapGet("/{id}", SavingsPortfolioReadEndpoints.Get);
        
        queries.MapGet("/id/{name}", SavingsPortfolioReadEndpoints.GetIdByName);

        queries.MapGet("/names", SavingsPortfolioReadEndpoints.GetNames);
        

    }
}