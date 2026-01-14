using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Abstractions;
using MoneyMinderClient.Services.Interfaces;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Requests.CurrencyAccounts;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinderClient.Services;

public class CurrencyAccountService : BaseService, ICurrencyAccountService
{
    private readonly HttpClient _httpClient;

    public CurrencyAccountService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
    }
    
    
    #region Commands
    
    public async Task<Result> PostCurrencyAccountAsync(CreateCurrencyAccountRequest request)
        => await SendAsync("api/CurrencyAccount", HttpMethod.Post, request);    
    
    public async Task<Result> PatchCurrencyAccountAsync(ChangeCurrencyAccountNameRequest request)
        => await SendAsync("api/CurrencyAccount", HttpMethod.Patch, request);    
    
    public async Task<Result> DeleteCurrencyAccountAsync(DeleteCurrencyAccountRequest request)
        => await SendAsync("api/CurrencyAccount", HttpMethod.Delete, request);

    public async Task<Result> PostIncomeAsync(AddIncomeRequest request)
        => await SendAsync("api/CurrencyAccount/Income", HttpMethod.Post, request);

    public async Task<Result> RemoveIncomeAsync(RemoveIncomeRequest request)
        => await SendAsync("api/CurrencyAccount/Income", HttpMethod.Delete, request);

    public async Task<Result> PostPaymentAsync(AddPaymentRequest request)
        => await SendAsync("api/CurrencyAccount/Payment", HttpMethod.Post, request);

    public async Task<Result> RemovePaymentAsync(RemovePaymentRequest request)
        => await SendAsync("api/CurrencyAccount/Payment", HttpMethod.Delete, request);

    public async Task<Result> PostBudgetAsync(CreateBudgetRequest request)
        => await SendAsync("api/CurrencyAccount/Budget", HttpMethod.Post, request);
    
    public async Task<Result> DeleteBudgetAsync(DeleteBudgetRequest request)
        => await SendAsync("api/CurrencyAccount/Budget", HttpMethod.Delete, request);

    public async Task<Result> PutLimitAsync(EditLimitRequest request)
        => await SendAsync("api/CurrencyAccount/Budget/Limit", HttpMethod.Put, request);

    public async Task<Result> ConvertCurrencyAsync(ConvertCurrencyRequest request)
        => await SendAsync("api/CurrencyAccount/Convert", HttpMethod.Post, request);

    public async Task<Result<GetCurrencyAccountReportPaymentsResponse>> PostPaymentsReportAsync(PostPaymentsReportRequest request)
        => await PostReportAsync<PostPaymentsReportRequest, GetCurrencyAccountReportPaymentsResponse>("api/CurrencyAccount/PaymentsReport", request);

    public async Task<Result<GetCurrencyAccountReportPaymentsResponse>> PostAllTimePaymentsReportAsync(PostAllTimePaymentsReportRequest request)
        => await PostReportAsync<PostAllTimePaymentsReportRequest, GetCurrencyAccountReportPaymentsResponse>("api/CurrencyAccount/AllTimePaymentsReport", request);

    public async Task<Result<GetCurrencyAccountBalanceReportResponse>> PostBalanceReportAsync(PostBalanceReportRequest request)
        => await PostReportAsync<PostBalanceReportRequest, GetCurrencyAccountBalanceReportResponse>("api/CurrencyAccount/BalanceReport", request);
    
    public async Task<Result<GetCurrencyAccountBalanceReportResponse>> PostAllTimeBalanceReportAsync(PostAllTimeBalanceReportRequest request)
            => await PostReportAsync<PostAllTimeBalanceReportRequest, GetCurrencyAccountBalanceReportResponse>("api/CurrencyAccount/AllTimeBalanceReport", request);


    #endregion
    
    #region Queries
    
    public async Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNamesAsync()
        => await GetAsync<GetCurrencyAccountNamesResponse>("api/CurrencyAccount/Names");
    
    public async Task<Result<GetCurrencyAccountsMetadataResponse>> GetCurrencyAccountsMetadataAsync()
        => await GetAsync<GetCurrencyAccountsMetadataResponse>($"api/CurrencyAccount/Metadata");
    
    public async Task<Result<GetCurrencyAccountMetadataByNameResponse>> GetCurrencyAccountMetadataByNameAsync(string name)
        => await GetAsync<GetCurrencyAccountMetadataByNameResponse>($"api/CurrencyAccount/Metadata/{name}");

    public async Task<Result<GetCurrencyAccountDetailsResponse>> GetCurrencyAccountDetailsAsync(string name)
        => await GetAsync<GetCurrencyAccountDetailsResponse>($"api/CurrencyAccount/Details/{name}");


    public async Task<Result<GetCurrencyAccountBalancesResponse>> GetCurrencyAccountBalancesAsync(Guid id)
        => await GetAsync<GetCurrencyAccountBalancesResponse>($"api/CurrencyAccount/{id}/Balances");

    public async Task<Result<GetCurrencyAccountTransactionsResponse>> GetCurrencyAccountTransactionsAsync(Guid id)
        => await GetAsync<GetCurrencyAccountTransactionsResponse>($"api/CurrencyAccount/{id}/Transactions");

    public async Task<Result<GetCurrencyAccountBudgetsResponse>> GetCurrencyAccountBudgetsAsync(Guid id)
        => await GetAsync<GetCurrencyAccountBudgetsResponse>($"api/CurrencyAccount/{id}/Budgets");

    public async Task<Result<GetCurrencyAccountMonthPaymentsResponse>> GetCurrencyAccountMonthPaymentsAsync(Guid id, DateTime month)
        => await GetAsync<GetCurrencyAccountMonthPaymentsResponse>($"api/CurrencyAccount/{id}/MonthPayments?month={month.ToString("yyyy-MM-dd")}");

    public async Task<Result<GetCurrencyAccountMonthPaymentsResponse>> GetCurrencyAccountMonthPaymentsAsync(Guid id, DateTime month, CurrencyDto currency)
        => await GetAsync<GetCurrencyAccountMonthPaymentsResponse>
            ($"api/CurrencyAccount/{id}/MonthPayments?month={month.ToString("yyyy-MM-dd")}&currency={currency.ToString()}");
    

    #endregion
}