using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Mappings;
using MoneyMinder.API.Services;
using MoneyMinder.Application.CurrencyAccounts.Commands;
using MoneyMinder.Domain.Shared.Enums;
using MoneyMinderContracts.Requests.CurrencyAccounts;

namespace MoneyMinder.API.Endpoints;

internal static class CurrencyAccountEndpoints
{
    [Authorize]
    public static async Task<IResult> PostCurrencyAccount(
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
    public static async Task<IResult> PatchCurrencyAccount(
        [FromBody]ChangeCurrencyAccountNameRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new ChangeCurrencyAccountNameCommand(accountId, request.CurrencyAccountId, request.Name);
        
        await sender.Send(command);
        return Results.Ok();
    }
        
    [Authorize]
    public static async Task<IResult> DeleteCurrencyAccount(
        [FromBody]DeleteCurrencyAccountRequest request, 
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
                
        var command = new DeleteCurrencyAccountCommand(accountId, request.CurrencyAccountId);
        
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

        var command = new AddIncomeCommand(accountId, request.CurrencyAccountId, request.Name, request.Date, (Currency)request.CurrencyDto, request.Amount);

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

        var command = new AddPaymentCommand(accountId, request.CurrencyAccountId, request.Name, request.Date, (Currency)request.CurrencyDto, request.Amount, (Category)request.CategoryDto);

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
    
    [Authorize]
    public static async Task<IResult> BudgetCreate(
        [FromBody] CreateBudgetRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();

        var command = new CreateBudgetCommand(accountId, request.CurrencyAccountId, request.Date, (Currency)request.CurrencyDto, request.Limits.ToDomain());

        await sender.Send(command);
                
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> LimitEdit(
        [FromBody] EditLimitRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();

        var command = new EditLimitCommand(accountId, request.CurrencyAccountId, request.Limit.ToDomain());

        await sender.Send(command);
                
        return Results.Ok();
    }
    
    [Authorize]
    public static async Task<IResult> BudgetDelete(
        [FromBody]DeleteBudgetRequest request,
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var accountId = userService.GetAccountId();

        var command = new DeleteBudgetCommand(accountId, request.CurrencyAccountId);

        await sender.Send(command);
                
        return Results.Ok();
    }
}