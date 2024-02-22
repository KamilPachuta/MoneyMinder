using Client.Models;
using Client.Models.ReadModels;
using Client.Models.Requests.CurrencyAccount.Commands;
using Client.Models.Responses;
using MoneyMinder.API.Requests.CurrencyAccounts;
using MoneyMinderClient.Models;

namespace Client.Services.Interfaces;

public interface ICurrencyAccountService
{
    public Task<Result> PutCurrencyAccount(CreateCurrencyAccountRequest request);
    public Task<Result> PostCurrencyAccount(ChangeCurrencyAccountNameRequest request);
    public Task<Result> DeleteCurrencyAccount(DeleteCurrencyAccountRequest request);
    
    public Task<Result> PostIncome(AddIncomeRequest request);
    public Task<Result> DeleteIncome(RemoveIncomeRequest request);

    public Task<Result> PostPayment(AddPaymentRequest request);
    public Task<Result> DeletePayment(RemovePaymentRequest request);

    public Task<Result> PutMonthlyIncome(AddMonthlyIncomeRequest request);
    public Task<Result> EditMonthlyIncome(EditMonthlyIncomeRequest request);
    public Task<Result> DeleteMonthlyIncome(RemoveMonthlyIncomeRequest request);
    public Task<Result> AcceptMonthlyIncome(AcceptMonthlyIncomeRequest request);
    
    public Task<Result> PutMonthlyPayment(AddMonthlyPaymentRequest request);
    public Task<Result> EditMonthlyPayment(EditMonthlyPaymentRequest request);
    public Task<Result> DeleteMonthlyPayment(RemoveMonthlyPaymentRequest request);
    public Task<Result> AcceptMonthlyPayment(AcceptMonthlyPaymentRequest request);

    public Task<Result> ConvertTo(ConvertCurrencyToRequest request);
    public Task<Result> ConvertFrom(ConvertCurrencyFromRequest request);

    public Task<Result> PutBudget(CreateBudgetRequest request);
    public Task<Result> PostBudget(ChangeBudgetNameRequest request);
    public Task<Result> DeleteBudget(DeleteBudgetRequest request);
    public Task<Result> PutExpense(AddExpenseRequest request);
    public Task<Result> PostExpense(EditExpenseRequest request);
    public Task<Result> DeleteExpense(RemoveExpenseRequest request);
    public Task<Result> ImportCSV(UploadCsvTransactionsRequest request);
    
    public Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNames();
    public Task<Result<GetCurrencyAccountDetailsResponse>> GetCurrencyAccountDetails(Guid id);
    public Task<Result<GetCurrencyAccountBalancesResponse>> GetCurrencyAccountBalances(Guid id);
    public Task<Result<GetCurrencyAccountTransactionsResponse>> GetCurrencyAccountTransactions(Guid id);
    public Task<Result<GetMonthlyTransactionsResponse>> GetMonthlyTransactions(Guid id);
    public Task<Result<GetCurrencyAccountIdByNameResponse>> GetIdByName(string name);
    
    public Task<Result<GetCurrencyIncomesResponse>> GetCurrencyIncomes(Guid id);
    public Task<Result<GetCurrencyPaymentsResponse>> GetCurrencyPayments(Guid id); 
    public Task<Result<GetBudgetDetailsResponse>> GetBudgetDetails(Guid id);
    public Task<Result<GetCurrentMonthPaymentsResponse>> GetCurrentMonthPayments(Guid id);

}