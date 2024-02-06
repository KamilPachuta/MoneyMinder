using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Services;
using MoneyMinder.Application.Accounts.Queries;

namespace MoneyMinder.API.Endpoints;


internal static class AccountReadEndpoints
{
    [Authorize]
    public static async Task<IResult> Get(
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var id = userService.GetAccountId();

        var command = new GetAccount(id);

        var result = await sender.Send(command);

        return Results.Ok(result);
    }

    [Authorize]
    public static async Task<IResult> GetAll([FromServices] ISender sender)
    {
        var command = new GetAccounts();

        var result = await sender.Send(command);

        return Results.Ok(result);
    }
    
    [Authorize]
    public static async Task<IResult> GetPersonalInfo(
        [FromServices] ISender sender,
        [FromServices] IUserService userService)
    {
        var id = userService.GetAccountId();

        var command = new GetPersonalInfo(id);

        var result = await sender.Send(command);

        return Results.Ok(result);
    }
}