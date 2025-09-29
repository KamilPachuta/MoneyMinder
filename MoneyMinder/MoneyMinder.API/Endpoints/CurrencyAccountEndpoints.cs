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
    
    [Authorize]
    public static async Task<IResult> IncomeAdd(
        [FromBody] AddIncomeRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();

        var command = new AddIncomeCommand(accountId, request.CurrencyAccountId, request.Name, request.Date, request.Currency, request.Amount);

        await sender.Send(command);
                
        return Results.Ok();
    }
        
    [Authorize]
    public static async Task<IResult> IncomeRemove(
        [FromBody] RemoveIncomeRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();

        var command = new RemoveIncomeCommand(accountId, request.CurrencyAccountId, request.IncomeId);

        await sender.Send(command);
                
        return Results.Ok();
    }

    [Authorize]
    public static async Task<IResult> PaymentAdd(
        [FromBody] AddPaymentRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();

        var command = new AddPaymentCommand(accountId, request.CurrencyAccountId, request.Name, request.Date, request.Currency, request.Amount, request.Category);

        await sender.Send(command);
                
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> PaymentRemove(
        [FromBody] RemovePaymentRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();

        var command = new RemovePaymentCommand(accountId, request.CurrencyAccountId, request.PaymentId);

        await sender.Send(command);
                
        return Results.Ok();
    }
    
    public static async Task<IResult> BudgetCreate(
        [FromBody] CreateBudgetRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();

        var command = new CreateBudgetCommand(accountId, request.CurrencyAccountId, request.Date, request.Currency, request.Limits);

        await sender.Send(command);
                
        return Results.Ok();
    }
}