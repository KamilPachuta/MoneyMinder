using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Requests.SavingsPortfolios;
using MoneyMinder.API.Services;
using MoneyMinder.Application.Savings.Commands;

namespace MoneyMinder.API.Endpoints;

internal static class SavingsPortfolioEndpoints
{
    [Authorize]
    public static async Task<IResult> Put(
        [FromBody]CreateSavingsPortfolioRequest request,
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var command = new CreateSavingsPortfolioCommand(accountId, request.Name, request.Currency, request.PlannedAmount);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> Delete(
        [FromBody]DeleteSavingsPortfolioRequest request,
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var command = new DeleteSavingsPortfolioCommand(accountId, request.Id);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> PostName(
        [FromBody]ChangeSavingsNameRequest request,
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var command = new ChangeSavingsNameCommand(accountId, request.Id, request.Name);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> PostAmount(
        [FromBody]ChangeSavingsPlannedAmountRequest request,
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var command = new ChangeSavingsPlannedAmountCommand(accountId, request.Id, request.PlannedAmount);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> PostTransaction(
        [FromBody]ProcessSavingsTransactionRequest request,
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var command = new ProcessSavingsTransactionCommand(accountId, request.Id, request.Name, request.Date, request.Amount, request.Type);
        
        await sender.Send(command);
        return Results.Ok();
    }
}