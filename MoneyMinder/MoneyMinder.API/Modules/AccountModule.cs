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
        
        group.MapPut("/Admin/", AccountEndpoints.PutAdmin);

        group.MapPut("/", AccountEndpoints.PutUser);

        group.MapPost("/", AccountEndpoints.PostLogin);

        group.MapDelete("/", AccountEndpoints.DeleteAccount);
            
        group.MapPost("/password/", AccountEndpoints.PostPassword);
        
        group.MapPost("/name/", AccountEndpoints.PostName);

        group.MapPost("/phone/", AccountEndpoints.PostPhone);

        group.MapPost("/address", AccountEndpoints.PostAddress);
        
    }
}