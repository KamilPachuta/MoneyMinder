using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Requests.Accounts;
using MoneyMinder.Application.Accounts.Commands;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Domain.Accounts;

namespace MoneyMinder.API.Endpoints;

internal static class AccountEndpoints
{
    public static async Task<IResult> PutAdmin([FromBody]CreateAdminRequest request, [FromServices]ISender sender)
    {
        var command = new CreateAdmin(request.Email, request.Password);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    public static async Task<IResult> PutUser([FromBody]CreateUserRequest request, [FromServices]ISender sender)
    {
        var command = new CreateUser(request.Email, request.Password, request.FirstName, request.LastName, 
            request.PhoneCode, request.PhoneNumber, request.BirthDate, request.Gender, request.Country, request.City, request.PostalCode, request.Street);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    public static async Task<IResult> PostLogin([FromBody]LoginAccountRequest request, [FromServices]ISender sender)
    {
        var command = new LoginAccount(request.Email, request.Password);
        
        var result = await sender.Send(command);
        return Results.Ok(result);
    }
    
    public static async Task<IResult> Get([FromBody]GetAccountQuery request, [FromServices]ISender sender)
    {
        var command = new GetAccount(request.Id);

        var result = await sender.Send(command);

        return Results.Ok(result);
    }
    
    public static async Task<IResult> GetAll([FromServices]ISender sender)
    {
        var command = new GetAccounts();

        var result = await sender.Send(command);

        return Results.Ok(result);
    }
    
    public static async Task<IResult> PostPassword([FromBody]ChangePasswordRequest request, [FromServices] ISender sender)
    {
        var id = new Guid("4c7be10f-989d-424f-b0e9-4c34ffa2aa01");

        var command = new ChangePassword(id, request.Password, request.NewPassword);
        
        await sender.Send(command);

        return Results.Ok();
    }
    
    public static async Task<IResult> PostName([FromBody]ChangeNameRequest request, [FromServices]ISender sender)
    {
        var id = new Guid("4c7be10f-989d-424f-b0e9-4c34ffa2aa01");
        
        var command = new ChangeName(id, request.FirstName, request.LastName);

        await sender.Send(command);

        return Results.Ok();
    }

    public static async Task<IResult> PostPhone([FromBody]ChangePhoneNumberRequest request, [FromServices] ISender sender)
    {
        var id = new Guid("4c7be10f-989d-424f-b0e9-4c34ffa2aa01");

        var command = new ChangePhoneNumber(id, request.Code, request.Number);
        
        await sender.Send(command);

        return Results.Ok();
    }
    
    public static async Task<IResult> PostAddress([FromBody]ChangeAddressRequest request, [FromServices] ISender sender)
    {
        var id = new Guid("4c7be10f-989d-424f-b0e9-4c34ffa2aa01");

        var command = new ChangeAddress(id, request.Country, request.City, request.PostalCode, request.Street);
        
        await sender.Send(command);

        return Results.Ok();
    }
    
    
}