using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Requests.Accounts;
using MoneyMinder.API.Services;
using MoneyMinder.Application.Accounts.Commands;

namespace MoneyMinder.API.Endpoints;

internal static class AccountEndpoints
{
    [Authorize(Roles = "Admin")]
    public static async Task<IResult> PostAdmin([FromBody]CreateAdminRequest request, [FromServices]ISender sender)
    {
        var command = new CreateAdminCommand(request.Email, request.Password);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    public static async Task<IResult> PostUser([FromBody]CreateUserRequest request, [FromServices]ISender sender)
    {
        var command = new CreateUserCommand(request.Email, request.Password, request.FirstName, request.LastName, 
            request.PhoneCode, request.PhoneNumber, request.BirthDate, request.Gender, request.Country, request.City, request.PostalCode, request.Street);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    public static async Task<IResult> PostLogin([FromBody]LoginAccountRequest request, [FromServices]ISender sender)
    {
        var command = new LoginAccountCommand(request.Email, request.Password);
        
        var result = await sender.Send(command);
        return Results.Ok(result);
    }
    
    [Authorize]
    public static async Task<IResult> PatchPassword(
        [FromBody]ChangePasswordRequest request, 
        [FromServices] ISender sender,
        [FromServices]IUserService userService)
    {
        var id = userService.GetAccountId();

        var command = new ChangePasswordCommand(id, request.Password, request.NewPassword);
        
        await sender.Send(command);

        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> PatchName(
        [FromBody]ChangeNameRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var id = userService.GetAccountId();
        
        var command = new ChangeNameCommand(id, request.FirstName, request.LastName);

        await sender.Send(command);

        return Results.Ok();
    }

    [Authorize]
    public static async Task<IResult> PatchPhone(
        [FromBody]ChangePhoneNumberRequest request, 
        [FromServices] ISender sender,
        [FromServices]IUserService userService)
    {
        var id = userService.GetAccountId();

        var command = new ChangePhoneNumberCommand(id, request.Code, request.Number);
        
        await sender.Send(command);

        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> PutAddress(
        [FromBody]ChangeAddressRequest request, 
        [FromServices] ISender sender,
        [FromServices]IUserService userService)
    {
        var id = userService.GetAccountId();

        var command = new ChangeAddressCommand(id, request.Country, request.City, request.PostalCode, request.Street);
        
        await sender.Send(command);

        return Results.Ok();
    }

    [Authorize]
    public static async Task<IResult> DeleteAccount(
        [FromBody] DeleteAccountRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var id = userService.GetAccountId();

        var command = new DeleteAccountCommand(id, request.Password);
        
        await sender.Send(command);

        return Results.NoContent();
    }
}