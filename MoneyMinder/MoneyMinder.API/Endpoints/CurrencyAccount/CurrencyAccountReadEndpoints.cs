using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Services;
using MoneyMinder.Application.CurrencyAccounts.Queries;

namespace MoneyMinder.API.Endpoints.CurrencyAccount;

internal static class CurrencyAccountReadEndpoints
{
    public static async Task<IResult> GetCurrencyAccountNames(
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetCurrencyAccountNamesQuery(accountId);
        
        var result = await sender.Send(query);

        return Results.Ok(result);
    }
}