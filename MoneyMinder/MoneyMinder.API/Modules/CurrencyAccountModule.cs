using Carter;

namespace MoneyMinder.API.Modules;

public class CurrencyAccountModule : CarterModule
{
    public CurrencyAccountModule()
        : base("/CurrencyAccount")
    {

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        // app.MapPut("/Admin/", C.PutAdmin);
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