using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Services;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Application.CurrencyAccounts.Queries;

namespace MoneyMinder.API.Endpoints.Account;

internal static class AccountReadEndpoints
{
    [Authorize]
    public static async Task<IResult> GetUserDetails(
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetUserDetailsQuery(accountId);
        
        var result = await sender.Send(query);

        return Results.Ok(result);
    }
}