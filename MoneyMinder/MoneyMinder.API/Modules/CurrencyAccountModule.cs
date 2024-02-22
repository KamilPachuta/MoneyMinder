using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Modules.Abstractions;
using MoneyMinder.API.Services;
using MoneyMinder.Application.CurrencyAccounts.Commands;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace MoneyMinder.API.Modules;

public class CurrencyAccountModule : BaseModule
{
    public CurrencyAccountModule()
        : base("/CurrencyAccount")
    {

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var commands = app.MapGroup("").AddFluentValidationAutoValidation();

        commands.MapPut("/", CurrencyAccountEndpoints.Put);
        
        commands.MapPost("/", CurrencyAccountEndpoints.Post);
        
        commands.MapDelete("/", CurrencyAccountEndpoints.Delete);

        
        commands.MapPost("/income/", CurrencyAccountEndpoints.IncomeAdd);
        
        commands.MapDelete("/income/", CurrencyAccountEndpoints.IncomeRemove);

        
        commands.MapPost("/payment/", CurrencyAccountEndpoints.PaymentAdd);
        
        commands.MapDelete("/payment/", CurrencyAccountEndpoints.PaymentRemove);

        
        commands.MapPut("/monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeAdd);

        commands.MapPost("/monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeEdit);

        commands.MapDelete("/monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeRemove);

        commands.MapPost("/monthlyIncome/accept/", CurrencyAccountEndpoints.MonthlyIncomeAccept);
        
        
        commands.MapPut("/monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentAdd);

        commands.MapPost("/monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentEdit);

        commands.MapDelete("/monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentRemove);

        commands.MapPost("/monthlyPayment/accept/", CurrencyAccountEndpoints.MonthlyPaymentAccept);
        

        commands.MapPost("/convert/to", CurrencyAccountEndpoints.ConvertCurrencyTo);

        commands.MapPost("/convert/from", CurrencyAccountEndpoints.ConvertCurrencyFrom);
        
        
        commands.MapPut("/budget/", CurrencyAccountEndpoints.BudgetCreate);

        commands.MapPost("/budget/", CurrencyAccountEndpoints.BudgetEdit);

        commands.MapDelete("/budget/", CurrencyAccountEndpoints.BudgetDelete);
        
        commands.MapPut("/budget/expense/", CurrencyAccountEndpoints.ExpenseAdd);

        commands.MapPost("/budget/expense/", CurrencyAccountEndpoints.ExpenseEdit);

        commands.MapDelete("/budget/expense/", CurrencyAccountEndpoints.ExpenseDelete);

        commands.MapPost("/upload/{id}", async (HttpContext context, [FromServices]ISender sender, [FromServices]IUserService userService, [FromRoute]Guid id) =>
        {
            var accountId = userService.GetAccountId();
    
            var form = await context.Request.ReadFormAsync();
            var file = form.Files.GetFile("file");

            if (file is not null && file.ContentType == "text/csv")
            {
                
                var command = new UploadCsvTransactionsCommand(accountId, id, file);

                await sender.Send(command);
                
                return Results.Ok();

            }
            else
            {
            
                return Results.BadRequest("Unsupported Media Type. Sending file must be in CSV format.");
            }
    
    
            
        });
        //commands.MapPost("/upload/{id}", CurrencyAccountEndpoints.UploadCSV);

        
        var queries = app.MapGroup("").AddFluentValidationAutoValidation();

        queries.MapGet("/{id}", CurrencyAccountReadEndpoints.Get);
        
        queries.MapGet("/all/", CurrencyAccountReadEndpoints.GetAll);
        
        queries.MapGet("/names", CurrencyAccountReadEndpoints.GetNames);

        queries.MapGet("/{id}/balances", CurrencyAccountReadEndpoints.GetBalances);
        
        queries.MapGet("/{id}/transactions", CurrencyAccountReadEndpoints.GetTransactions);
        
        queries.MapGet("/{id}/monthlyTransactions", CurrencyAccountReadEndpoints.GetMonthlyTransactions);
        
        queries.MapGet("/id/{name}", CurrencyAccountReadEndpoints.GetIdByName);
        
        queries.MapGet("/{id}/incomes", CurrencyAccountReadEndpoints.GetIncomes);
        queries.MapGet("/{id}/payments", CurrencyAccountReadEndpoints.GetPayments);
        
        queries.MapGet("/{id}/budget", CurrencyAccountReadEndpoints.GetBudgetDetails);
        
        queries.MapGet("/{id}/currentPayments", CurrencyAccountReadEndpoints.GetCurrentMonthPayments);


        //app.MapGet("/", CurrencyAccountReadEndpoints.Get);
    }
}