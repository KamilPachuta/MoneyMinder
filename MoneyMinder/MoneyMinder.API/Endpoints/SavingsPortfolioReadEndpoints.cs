using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Services;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Application.Savings.Queries;

namespace MoneyMinder.API.Endpoints;

internal static class SavingsPortfolioReadEndpoints
{
    [Authorize]
    public static async Task<IResult> Get(
        [FromRoute]Guid id,
        [FromServices]ISender sender)
    {
        var query = new GetSavingsPortfolio(id);
        
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

        
        var query = new GetSavingsId(name, accountId);
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize]
    public static async Task<IResult> GetNames(
        [FromServices]IUserService userService,
        [FromServices]ISender sender)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetSavingsNames(accountId);
        
        var response = await sender.Send(query);
        
        return Results.Ok(response);
    }
  
    [Authorize]
    public static async Task<IResult> GetAllDetails(
        [FromServices]IUserService userService,
        [FromServices]ISender sender)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetAllSavingsDetails(accountId);
        
        var response = await sender.Send(query);
        
        return Results.Ok(response);
    }
}