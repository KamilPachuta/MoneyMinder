using Carter;
using MoneyMinder.API.Endpoints;
using MoneyMinder.API.Modules.Abstractions;

namespace MoneyMinder.API.Modules;

public class CurrencyAccountModule : BaseModule
{
    public CurrencyAccountModule()
        : base("/CurrencyAccount")
    {

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPut("/", CurrencyAccountEndpoints.Put);
        
        app.MapPost("/", CurrencyAccountEndpoints.Post);
        
        app.MapDelete("/", CurrencyAccountEndpoints.Delete);

        
        app.MapPost("/income/", CurrencyAccountEndpoints.IncomeAdd);
        
        app.MapDelete("/income/", CurrencyAccountEndpoints.IncomeRemove);

        
        app.MapPut("/payment/", CurrencyAccountEndpoints.PaymentAdd);
        
        app.MapDelete("/payment/", CurrencyAccountEndpoints.PaymentRemove);

        
        app.MapPut("/monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeAdd);

        app.MapPost("monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeEdit);

        app.MapDelete("/monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeRemove);

        app.MapPost("/monthlyIncome/accept/", CurrencyAccountEndpoints.MonthlyIncomeAccept);
        
        
        app.MapPut("/monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentAdd);

        app.MapPost("monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentEdit);

        app.MapDelete("/monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentRemove);

        app.MapPost("/monthlyPayment/accept/", CurrencyAccountEndpoints.MonthlyPaymentAccept);
        

        app.MapPost("/convert/to", CurrencyAccountEndpoints.ConvertCurrencyTo);

        app.MapPost("/convert/from", CurrencyAccountEndpoints.ConvertCurrencyFrom);
        
        
        app.MapPut("/budget/", CurrencyAccountEndpoints.BudgetCreate);

        app.MapPost("/budget/", CurrencyAccountEndpoints.BudgetEdit);

        app.MapDelete("/budget/", CurrencyAccountEndpoints.BudgetDelete);
        
        app.MapPut("/budget/expense/", CurrencyAccountEndpoints.ExpenseAdd);

        app.MapPost("/budget/expense/", CurrencyAccountEndpoints.ExpenseEdit);

        app.MapDelete("/budget/expense/", CurrencyAccountEndpoints.ExpenseDelete);


        app.MapGet("/", CurrencyAccountReadEndpoints.GetAll);

        //app.MapGet("/", CurrencyAccountReadEndpoints.Get);
    }
}