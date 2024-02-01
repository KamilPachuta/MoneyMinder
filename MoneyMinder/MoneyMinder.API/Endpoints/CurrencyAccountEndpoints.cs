using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API.Requests.CurrencyAccounts;
using MoneyMinder.API.Services;
using MoneyMinder.Application.CurrencyAccounts.Commands;


namespace MoneyMinder.API.Endpoints;

internal static  class CurrencyAccountEndpoints
{
        [Authorize]
        public static async Task<IResult> Put(
                [FromBody]CreateCurrencyAccountRequest request, 
                [FromServices]ISender sender,
                [FromServices]IUserService userService)
        {
                var accountId = userService.GetAccountId();
                
                var command = new CreateCurrencyAccountCommand(accountId, request.Name);
        
                await sender.Send(command);
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> Post(
                [FromBody]ChangeCurrecnyAccountNameRequest request, 
                [FromServices]ISender sender,
                [FromServices]IUserService userService)
        {
                var accountId = userService.GetAccountId();
                
                var command = new ChangeCurrecnyAccountNameCommand(accountId, request.Id, request.Name);
        
                await sender.Send(command);
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> Delete(
                [FromBody]DeleteCurrencyAccountRequest request, 
                [FromServices]ISender sender,
                [FromServices]IUserService userService)
        {
                var accountId = userService.GetAccountId();
                
                var command = new DeleteCurrencyAccountCommand(accountId, request.Id);
        
                await sender.Send(command);
                return Results.Ok();
        }

        [Authorize]
        public static async Task<IResult> IncomeAdd(
                [FromBody] AddIncomeRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new AddIncomeCommand(accountId, request.Id, request.Name, request.Date, request.Currency, request.Amount);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        
        [Authorize]
        public static async Task<IResult> IncomeRemove(
                [FromBody] RemoveIncomeRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new RemoveIncomeCommand(accountId, request.CurrencyAccountId, request.IncomeId);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        
        [Authorize]
        public static async Task<IResult> PaymentAdd(
                [FromBody] AddPaymentRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new AddPaymentCommand(accountId, request.Id, request.Name, request.Date, request.Currency, request.Amount, request.Category);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> PaymentRemove(
                [FromBody] RemovePaymentRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new RemovePaymentCommand(accountId, request.CurrencyAccountId, request.PaymentId);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> MonthlyIncomeAdd(
                [FromBody] AddMonthlyIncomeRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new AddMonthlyIncomeCommand(accountId, request.Id, request.Name, request.Date, request.Currency, request.Amount);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> MonthlyIncomeEdit(
                [FromBody] EditMonthlyIncomeRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new EditMonthlyIncomeCommand(accountId, request.Id, request.Name, request.NewAmount, request.NewCurrency);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> MonthlyIncomeRemove(
                [FromBody] RemoveMonthlyIncomeRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new RemoveMonthlyIncomeCommand(accountId, request.Id, request.MonthlyIncomeName);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> MonthlyIncomeAccept(
                [FromBody] AcceptMonthlyIncomeRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new AcceptMonthlyIncomeCommand(accountId, request.Id, request.Name,
                        request.Amount, request.Currency);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> MonthlyPaymentAdd(
                [FromBody] AddMonthlyPaymentRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new AddMonthlyPaymentCommand(accountId, request.Id, request.Name, request.Date, request.Currency, request.Amount, request.Category);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> MonthlyPaymentEdit(
                [FromBody] EditMonthlyPaymentRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new EditMonthlyPaymentCommand(accountId, request.Id, request.Name, request.NewAmount, request.NewCurrency);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> MonthlyPaymentRemove(
                [FromBody] RemoveMonthlyPaymentRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new RemoveMonthlyPaymentCommand(accountId, request.Id, request.MonthlyPaymentName);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        [Authorize]
        public static async Task<IResult> MonthlyPaymentAccept(
                [FromBody] AcceptMonthlyIncomeRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new AcceptMonthlyPaymentCommand(accountId, request.Id, request.Name,
                        request.Amount, request.Currency);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        public static async Task<IResult> ConvertCurrencyTo(
                [FromBody] ConvertCurrencyToRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new ConvertCurrencyToCommand(accountId, request.Id, request.From,
                        request.To, request.Amount, request.Coefficient);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        public static async Task<IResult> ConvertCurrencyFrom(
                [FromBody] ConvertCurrencyFromRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new ConvertCurrencyFromCommand(accountId, request.Id, request.From,
                        request.To, request.Amount, request.Coefficient);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        public static async Task<IResult> BudgetCreate(
                [FromBody]CreateBudgetRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new CreateBudgetCommand(accountId, request.Id, request.Name,
                        request.ExpectedIncome, request.Expenses, request.Date, request.Currency);

                await sender.Send(command);
                
                return Results.Ok();
        }
    
        public static async Task<IResult> BudgetEdit(
                [FromBody]ChangeBudgetNameRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new ChangeBudgetNameCommand(accountId, request.Id, request.Name);
                
                await sender.Send(command);
                
                return Results.Ok();
        }
        
        public static async Task<IResult> BudgetDelete(
                [FromBody]DeleteBudgetRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new DeleteBudgetCommand(accountId, request.Id);

                await sender.Send(command);
                
                return Results.Ok();
        }
        
        public static async Task<IResult> ExpenseAdd(
                [FromBody]AddExpenseRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new AddExpenseCommand(accountId, request.Id, request.Category, request.ExpenseAmount);

                await sender.Send(command);
                
                return Results.Ok();
        }
    
        public static async Task<IResult> ExpenseEdit(
                [FromBody]EditExpenseRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new EditExpenseCommand(accountId, request.Id, request.Category, request.ExpenseAmount);
                
                await sender.Send(command);
                
                return Results.Ok();
        }
        
        public static async Task<IResult> ExpenseDelete(
                [FromBody]RemoveExpenseRequest request,
                [FromServices] ISender sender,
                [FromServices] IUserService userService)
        {
                var accountId = userService.GetAccountId();

                var command = new RemoveExpenseCommand(accountId, request.Id, request.Category);

                await sender.Send(command);
                
                return Results.Ok();
        }
}