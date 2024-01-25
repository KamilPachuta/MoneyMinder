using Carter;
using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Modules.Abstractions;

namespace MoneyMinder.API.Modules;

public class CurrencyAccountModule : BaseModule
{
    public CurrencyAccountModule()
        : base("/CurrencyAccount")
    {

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPut("/", CurrencyAccountEndpoints.Put);
        app.MapPost("/", CurrencyAccountEndpoints.Post);
        app.MapDelete("/", CurrencyAccountEndpoints.Delete);
        //
        // app.MapPut("/", AccountEndpoints.PutUser);
        //
        // app.MapGet("/", AccountEndpoints.Get);
        //
        // app.MapGet("/all/", AccountEndpoints.GetAll);


        // app.MapPut("/CurrencyAccount",AccountEndpoints);
        // app.MapGet("/Savings",);


    }
}