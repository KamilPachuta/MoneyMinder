using MoneyMinderClient.Core;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Requests.CurrencyAccounts;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinderClient.Services.Interfaces;

public interface ICurrencyAccountService
{
    public Task<Result> PostCurrencyAccountAsync(CreateCurrencyAccountRequest request);
    public Task<Result> PatchCurrencyAccountAsync(ChangeCurrencyAccountNameRequest request);
    public Task<Result> DeleteCurrencyAccountAsync(DeleteCurrencyAccountRequest request);
    
    public Task<Result> PostIncomeAsync(AddIncomeRequest request);
    public Task<Result> RemoveIncomeAsync(RemoveIncomeRequest request);
    
    public Task<Result> PostPaymentAsync(AddPaymentRequest request);
    public Task<Result> RemovePaymentAsync(RemovePaymentRequest request);
    
    // public Task<Result> ImportCSVAsync(UploadCsvTransactionsRequest request);
    
    // public Task<Result> ConvertToAsync(ConvertCurrencyToRequest request);
    // public Task<Result> ConvertFromAsync(ConvertCurrencyFromRequest request);
    
    public Task<Result<GetCurrencyAccountReportPaymentsResponse>> PostPaymentsReportAsync(PostPaymentsReportRequest request);
    public Task<Result<GetCurrencyAccountReportPaymentsResponse>> PostAllTimePaymentsReportAsync(PostAllTimePaymentsReportRequest request);
    
    public Task<Result<GetCurrencyAccountBalanceReportResponse>> PostBalanceReportAsync(PostBalanceReportRequest request);
    public Task<Result<GetCurrencyAccountBalanceReportResponse>> PostAllTimeBalanceReportAsync(PostAllTimeBalanceReportRequest request);
    
    
    public Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNamesAsync();
    public Task<Result<GetCurrencyAccountsMetadataResponse>> GetCurrencyAccountsMetadataAsync();
    public Task<Result<GetCurrencyAccountMetadataByNameResponse>> GetCurrencyAccountMetadataByNameAsync(string name);
    public Task<Result<GetCurrencyAccountDetailsResponse>> GetCurrencyAccountDetailsAsync(string name);
    public Task<Result<GetCurrencyAccountBalancesResponse>> GetCurrencyAccountBalancesAsync(Guid id);
    public Task<Result<GetCurrencyAccountTransactionsResponse>> GetCurrencyAccountTransactionsAsync(Guid id);
    

    public Task<Result<GetCurrencyAccountBudgetsResponse>> GetCurrencyAccountBudgetsAsync(Guid id);
    public Task<Result<GetCurrencyAccountMonthPaymentsResponse>> GetCurrencyAccountMonthPaymentsAsync(Guid id, DateTime month);
    public Task<Result<GetCurrencyAccountMonthPaymentsResponse>> GetCurrencyAccountMonthPaymentsAsync(Guid id, DateTime month, CurrencyDto currency);
}