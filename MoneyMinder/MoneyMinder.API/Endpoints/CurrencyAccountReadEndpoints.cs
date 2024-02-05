using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Requests.CurrencyAccounts;
using MoneyMinder.API.Requests.CurrencyAccounts.Query;
using MoneyMinder.API.Services;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Application.CurrencyAccounts.Commands;
using MoneyMinder.Application.CurrencyAccounts.Queries;

namespace MoneyMinder.API.Endpoints;

internal static class CurrencyAccountReadEndpoints
{
    [Authorize]
    public static async Task<IResult> Get(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {

        var query = new Get(id);
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetAll([FromServices]ISender sender)
    {
        var query = new GetAll();
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetNames(
        [FromServices]ISender sender, 
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetNames(accountId);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetBalances(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {
        var query = new GetBalances(id);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetIdByName(
        [FromRoute]string name,
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();

        
        var query = new GetIdByName(name, accountId);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetTransactions(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {
        var query = new GetTransactions(id);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetMonthlyTransactions(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {
        var query = new GetMonthlyTransactions(id);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetIncomes(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {
        var query = new GetCurrencyAccountMonthIncomes(id);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetPayments(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {
        var query = new GetCurrencyAccountMonthPayments(id);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetCurrentMonthPayments(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {
        var query = new GetActualExpensesFromCurrentMonth(id);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetBudgetDetails(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {
        var query = new GetBudgetDetails(id);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
}