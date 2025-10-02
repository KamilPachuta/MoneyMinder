using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Services;
using MoneyMinder.Application.SavingsAccounts.Queries;
using MoneyMinderContracts.Responses.Accounts;

namespace MoneyMinder.API.Endpoints.SavingsAccount;

internal static class SavingsAccountReadEndpoints
{
    public static async Task<IResult> GetSavingsAccountNames(
        [FromServices]ISender sender,
        [FromServices]IUserService userService)
    {
        var accountId = userService.GetAccountId();
        
        var query = new GetSavingsAccountNamesQuery(accountId);
        
        var result = await sender.Send(query);

        return Results.Ok(result);
    }
}