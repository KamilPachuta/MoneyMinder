using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Endpoints.Account;
using MoneyMinder.API.Modules.Abstractions;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace MoneyMinder.API.Modules;

public class AccountModule : BaseModule
{
    public AccountModule()
        : base("/Account")
    {
        
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("").AddFluentValidationAutoValidation();
        
        group.MapPost("/Admin/", AccountEndpoints.PostAdmin);

        group.MapPost("/User/", AccountEndpoints.PostUser);

        group.MapPost("/", AccountEndpoints.PostLogin);

        group.MapDelete("/", AccountEndpoints.DeleteAccount);
            
        group.MapPatch("/Password/", AccountEndpoints.PatchPassword);
        
        group.MapPatch("/Name/", AccountEndpoints.PatchName);

        group.MapPatch("/Phone/", AccountEndpoints.PatchPhone);

        group.MapPut("/Address", AccountEndpoints.PutAddress);
        
    }
}