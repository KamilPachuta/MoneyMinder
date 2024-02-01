using Carter;
using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Modules.Abstractions;
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

        commands.MapPost("monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeEdit);

        commands.MapDelete("/monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeRemove);

        commands.MapPost("/monthlyIncome/accept/", CurrencyAccountEndpoints.MonthlyIncomeAccept);
        
        
        commands.MapPut("/monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentAdd);

        commands.MapPost("monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentEdit);

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

        var queries = app.MapGroup("").AddFluentValidationAutoValidation();

        queries.MapGet("/{id}", CurrencyAccountReadEndpoints.Get);
        
        queries.MapGet("/all/", CurrencyAccountReadEndpoints.GetAll);
        
        queries.MapGet("/names", CurrencyAccountReadEndpoints.GetNames);

        queries.MapGet("/{id}/balances", CurrencyAccountReadEndpoints.GetBalances);
        
        queries.MapGet("/{id}/transactions", CurrencyAccountReadEndpoints.GetTransactions);
        
        queries.MapGet("/{id}/monthlyTransactions", CurrencyAccountReadEndpoints.GetMonthlyTransactions);
        
        queries.MapGet("/id/{name}", CurrencyAccountReadEndpoints.GetIdByName);


        //app.MapGet("/", CurrencyAccountReadEndpoints.Get);
    }
}