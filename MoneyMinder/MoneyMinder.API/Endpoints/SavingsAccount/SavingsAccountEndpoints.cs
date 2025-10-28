using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Services;
using MoneyMinder.Application.SavingsAccounts.Commands;
using MoneyMinder.Application.SavingsAccounts.Queries;
using MoneyMinder.Domain.SavingsAccounts.Enums;
using MoneyMinder.Domain.Shared.Enums;
using MoneyMinderContracts.Requests.SavingsAccounts;

namespace MoneyMinder.API.Endpoints.SavingsAccount;

internal static class SavingsAccountEndpoints
{
    [Authorize]
    public static async Task<IResult> PostSavingsAccount(
        [FromBody]CreateSavingsAccountRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new CreateSavingsAccountCommand(accountId, request.Name, (Currency)request.CurrencyDto, request.PlannedAmount);
        
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
    
    [Authorize]
    public static async Task<IResult> PatchSavingsAccountPlannedAmount(
        [FromBody]ChangeSavingsAccountPlannedAmountRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new ChangeSavingsAccountPlannedAmountCommand(accountId, request.SavingsAccountId, request.PlannedAmount);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> PostSavingsTransaction(
        [FromBody]ProcessSavingsTransactionRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new ProcessSavingsTransactionCommand(
            accountId, 
            request.SavingsAccountId, 
            request.Name, 
            request.Date.Value, 
            (Currency)request.CurrencyDto, 
            request.Amount, 
            (TransactionType)request.TransactionType);
        
        await sender.Send(command);
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> SavingsReport(
        [FromBody]PostSavingsReportRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();
    
        var query = new GetSavingsReportQuery(
            accountId, 
            request.SavingsAccountIds, 
            request.From, 
            request.To);
            
        var response = await sender.Send(query);
                    
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> AllTimeSavingsReport(
        [FromBody]PostAllTimeSavingsReportRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();
    
        var query = new GetAllTimeSavingsReportQuery(
            accountId, 
            request.SavingsAccountIds);
            
        var response = await sender.Send(query);
                    
        return Results.Ok(response);
    }
}