using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Requests.CurrencyAccounts;
using MoneyMinder.API.Services;
using MoneyMinder.Application.CurrencyAccounts.Commands;

namespace MoneyMinder.API.Endpoints;

internal static class CurrencyAccountEndpoints
{
    [Authorize]
    public static async Task<IResult> Put(
        [FromBody]CreateCurrencyAccountRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new CreateCurrencyAccountCommand(accountId, request.Name);
        
        await sender.Send(command);
        return Results.Ok();
    }
        
    [Authorize]
    public static async Task<IResult> Post(
        [FromBody]ChangeCurrencyAccountNameRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new ChangeCurrencyAccountNameCommand(accountId, request.Id, request.Name);
        
        await sender.Send(command);
        return Results.Ok();
    }
        
    [Authorize]
    public static async Task<IResult> Delete(
        [FromBody]DeleteCurrencyAccountRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new DeleteCurrencyAccountCommand(accountId, request.Id);
        
        await sender.Send(command);
        return Results.Ok();
    }
}