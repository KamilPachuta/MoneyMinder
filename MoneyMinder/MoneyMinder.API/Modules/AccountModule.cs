using MoneyMinder.API.Endpoints;
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

        group.MapPost("/", AccountEndpoints.PostUser);

        group.MapPost("/", AccountEndpoints.PostLogin);

        group.MapDelete("/", AccountEndpoints.DeleteAccount);
            
        group.MapPatch("/password/", AccountEndpoints.PatchPassword);
        
        group.MapPatch("/name/", AccountEndpoints.PatchName);

        group.MapPatch("/phone/", AccountEndpoints.PatchPhone);

        group.MapPut("/address", AccountEndpoints.PutAddress);
        
    }
}