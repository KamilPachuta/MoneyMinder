using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Modules.Abstractions;

namespace MoneyMinder.API.Modules;

public class SavingsPortfolioModule : BaseModule
{
    public SavingsPortfolioModule() 
        : base("/Savings/")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/", SavingsPortfolioEndpoints.Put);

        app.MapDelete("/", SavingsPortfolioEndpoints.Delete);
        
        app.MapPost("/Name/", SavingsPortfolioEndpoints.PostName);

        app.MapPost("/PlannedAmount/", SavingsPortfolioEndpoints.PostAmount);

        app.MapPost("/transaction/", SavingsPortfolioEndpoints.PostTransaction);

    }
}