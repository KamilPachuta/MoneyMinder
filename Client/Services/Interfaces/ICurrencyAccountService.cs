using Client.Models.ReadModels;
using Client.Models.Requests.CurrencyAccount.Commands;
using Client.Models.Responses;
using MoneyMinder.API.Requests.CurrencyAccounts;
using MoneyMinderClient.Models;

namespace Client.Services.Interfaces;

public interface ICurrencyAccountService
{
    public Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNames();
    public Task<Result<GetCurrencyAccountBalancesResponse>> GetCurrencyAccountBalances(Guid id);
    public Task<Result<GetCurrencyAccountTransactionsResponse>> GetCurrencyAccountTransactions(Guid id);
    public Task<Result<GetMonthlyTransactionsResponse>> GetMonthlyTransactions(Guid id);
    public Task<Result<GetCurrencyAccountIdByNameResponse>> GetIdByName(string name);

    public Task<Result> PutCurrencyAccount(CreateCurrencyAccountRequest request);
    public Task<Result> PostCurrencyAccount(ChangeCurrencyAccountNameRequest request);
    public Task<Result> PostIncome(AddIncomeRequest request);
    public Task<Result> PostPayment(AddPaymentRequest request);
    public Task<Result> PutMonthlyIncome(AddMonthlyIncomeRequest request);
    public Task<Result> PutMonthlyPayment(AddMonthlyPaymentRequest request);
    public Task<Result> DeleteIncome(RemoveIncomeRequest request);
    public Task<Result> DeletePayment(RemovePaymentRequest request);
    public Task<Result> EditMonthlyIncome(EditMonthlyIncomeRequest request);
    public Task<Result> DeleteMonthlyIncome(RemoveMonthlyIncomeRequest request);
    public Task<Result> EditMonthlyPayment(EditMonthlyPaymentRequest request);
    public Task<Result> DeleteMonthlyPayment(RemoveMonthlyPaymentRequest request);
}