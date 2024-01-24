using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Requests.Accounts;
using MoneyMinder.Application.Accounts.Commands;
using MoneyMinder.Application.Accounts.Queries;

namespace MoneyMinder.API.Modules;

public class AccountModule : CarterModule
{
    public AccountModule()
        : base("/Account")
    {
        
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/Admin/", AccountEndpoints.PutAdmin);

        app.MapPut("/", AccountEndpoints.PutUser);

        app.MapPost("/", AccountEndpoints.PostLogin);
        
        app.MapGet("/", AccountEndpoints.Get);

        app.MapGet("/all/", AccountEndpoints.GetAll);

        app.MapPost("/password/", AccountEndpoints.PostPassword);
        
        app.MapPost("/name/", AccountEndpoints.PostName);

        app.MapPost("/phone/", AccountEndpoints.PostPhone);

        app.MapPost("/address", AccountEndpoints.PostAddress);

        // app.MapPut("/CurrencyAccount",AccountEndpoints);
        // app.MapGet("/Savings",);


    }
}