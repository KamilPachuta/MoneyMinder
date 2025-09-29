using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Requests.SavingsAccounts;
using MoneyMinder.API.Services;
using MoneyMinder.Application.CurrencyAccounts.Commands;
using MoneyMinder.Application.SavingsAccounts.Commands;

namespace MoneyMinder.API.Endpoints;

internal static class SavingsAccountEndpoints
{
    [Authorize]
    public static async Task<IResult> PostSavingsAccount(
        [FromBody]CreateSavingsAccountRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new CreateSavingsAccountCommand(accountId, request.Name, request.Currency, request.PlannedAmount);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> DeleteSavingsAccount(
        [FromBody]DeleteSavingsAccountRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new DeleteSavingsAccountCommand(accountId, request.SavingsAccountId);
        
        await sender.Send(command);
        return Results.NoContent();
    }
    
    [Authorize]
    public static async Task<IResult> PatchSavingsAccountName(
        [FromBody]ChangeSavingsAccountNameRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new ChangeSavingsAccountNameCommand(accountId, request.SavingsAccountId, request.Name);
        
        await sender.Send(command);
        return Results.Ok();
    }
}