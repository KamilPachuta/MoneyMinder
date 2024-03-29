using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Requests.Accounts;
using MoneyMinder.API.Services;
using MoneyMinder.Application.Accounts.Commands;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Domain.Accounts;

namespace MoneyMinder.API.Endpoints;

internal static class AccountEndpoints
{
    [Authorize]
    public static async Task<IResult> PutAdmin([FromBody]CreateAdminRequest request, [FromServices]ISender sender)
    {
        var command = new CreateAdminCommand(request.Email, request.Password);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    public static async Task<IResult> PutUser([FromBody]CreateUserRequest request, [FromServices]ISender sender)
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
    public static async Task<IResult> PostPassword(
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
    public static async Task<IResult> PostName(
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
    public static async Task<IResult> PostPhone(
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
    public static async Task<IResult> PostAddress(
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
    public static async Task<IResult> PostNotification(
        [FromBody]AddNotificationRequest request, 
        [FromServices] ISender sender,
        [FromServices]IUserService userService)
    {
        var id = userService.GetAccountId();

        var command = new AddNotificationCommand(id, request.Title, request.Description);
        
        await sender.Send(command);

        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> ClearNotifications(
        [FromServices] ISender sender,
        [FromServices]IUserService userService)
    {
        var id = userService.GetAccountId();

        var command = new ClearNotificationsCommand(id);
        
        await sender.Send(command);

        return Results.Ok();
    }
}