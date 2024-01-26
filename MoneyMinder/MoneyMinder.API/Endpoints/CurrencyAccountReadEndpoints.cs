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
        [FromQuery]GetCurrencyAccount query,
        [FromServices]ISender sender)
    {
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
    
    [Authorize] // Rola Admin
    public static async Task<IResult> GetAll([FromServices]ISender sender)
    {
        var query = new GetCurrencyAccounts();
        
        var response = await sender.Send(query);
        return Results.Ok(response);
    }
}