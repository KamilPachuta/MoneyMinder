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
        var group = app.MapGroup("").AddFluentValidationAutoValidation();

        group.MapPut("/", CurrencyAccountEndpoints.Put);
        
        group.MapPost("/", CurrencyAccountEndpoints.Post);
        
        group.MapDelete("/", CurrencyAccountEndpoints.Delete);

        
        group.MapPost("/income/", CurrencyAccountEndpoints.IncomeAdd);
        
        group.MapDelete("/income/", CurrencyAccountEndpoints.IncomeRemove);

        
        group.MapPut("/payment/", CurrencyAccountEndpoints.PaymentAdd);
        
        group.MapDelete("/payment/", CurrencyAccountEndpoints.PaymentRemove);

        
        group.MapPut("/monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeAdd);

        group.MapPost("monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeEdit);

        group.MapDelete("/monthlyIncome", CurrencyAccountEndpoints.MonthlyIncomeRemove);

        group.MapPost("/monthlyIncome/accept/", CurrencyAccountEndpoints.MonthlyIncomeAccept);
        
        
        group.MapPut("/monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentAdd);

        group.MapPost("monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentEdit);

        group.MapDelete("/monthlyPayment", CurrencyAccountEndpoints.MonthlyPaymentRemove);

        group.MapPost("/monthlyPayment/accept/", CurrencyAccountEndpoints.MonthlyPaymentAccept);
        

        group.MapPost("/convert/to", CurrencyAccountEndpoints.ConvertCurrencyTo);

        group.MapPost("/convert/from", CurrencyAccountEndpoints.ConvertCurrencyFrom);
        
        
        group.MapPut("/budget/", CurrencyAccountEndpoints.BudgetCreate);

        group.MapPost("/budget/", CurrencyAccountEndpoints.BudgetEdit);

        group.MapDelete("/budget/", CurrencyAccountEndpoints.BudgetDelete);
        
        group.MapPut("/budget/expense/", CurrencyAccountEndpoints.ExpenseAdd);

        group.MapPost("/budget/expense/", CurrencyAccountEndpoints.ExpenseEdit);

        group.MapDelete("/budget/expense/", CurrencyAccountEndpoints.ExpenseDelete);


        group.MapGet("/", CurrencyAccountReadEndpoints.GetAll);

        //app.MapGet("/", CurrencyAccountReadEndpoints.Get);
    }
}