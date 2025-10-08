using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Services;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

namespace MoneyMinder.API.Endpoints.CurrencyAccount;

internal static class CurrencyAccountReadEndpoints
{
    [Authorize]
    public static async Task<IResult> GetCurrencyAccountNames(
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetCurrencyAccountNamesQuery(accountId);
        
        var result = await sender.Send(query);

        return Results.Ok(result);
    }
    
    [Authorize]
    public static async Task<IResult> GetCurrencyAccountIdByName(
        [FromRoute]string name,
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetCurrencyAccountIdByNameQuery(accountId, name);
        
        var response = await sender.Send(query);
        
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetCurrencyAccountDetails(
        [FromRoute]string name,
        [FromServices]IUserService userService,
        [FromServices]ISender sender)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetCurrencyAccountDetailsQuery(accountId, name);
        
        var response = await sender.Send(query);
        
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetCurrencyAccountBalances(
        [FromRoute]Guid id,
        [FromServices]IUserService userService,
        [FromServices]ISender sender)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetBalancesQuery(accountId, id);
        
        var response = await sender.Send(query);
        
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetCurrencyAccountTransactions(
        [FromRoute]Guid id,
        [FromServices]IUserService userService,
        [FromServices]ISender sender)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetCurrencyAccountTransactionsQuery(accountId, id);
        
        var response = await sender.Send(query);
        
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetCurrencyAccountTransactionsByDate(
        [FromRoute]Guid id,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate,
        [FromServices]IUserService userService,
        [FromServices]ISender sender)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetCurrencyAccountTransactionsByDateQuery(accountId, id, startDate, endDate);
        
        var response = await sender.Send(query);
        
        return Results.Ok(response);
    }
}