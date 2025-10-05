using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Abstractions;
using MoneyMinderClient.Services.Interfaces;
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

    public async Task<Result> PostPaymentAsync(AddPaymentRequest request)
        => await SendAsync("api/CurrencyAccount/Payment", HttpMethod.Post, request);

    #endregion
    
    #region Queries
    
    public async Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNamesAsync()
        => await GetAsync<GetCurrencyAccountNamesResponse>("api/CurrencyAccount/Names");
    
    public async Task<Result<GetCurrencyAccountIdByNameResponse>> GetIdByNameAsync(string name)
        => await GetAsync<GetCurrencyAccountIdByNameResponse>($"api/CurrencyAccount/Id/{name}");
    
    public async Task<Result<GetCurrencyAccountBalancesResponse>> GetCurrencyAccountBalancesAsync(Guid id)
        => await GetAsync<GetCurrencyAccountBalancesResponse>($"api/CurrencyAccount/{id}/Balances");

    public async Task<Result<GetCurrencyAccountTransactionsResponse>> GetCurrencyAccountTransactionsAsync(Guid id)
        => await GetAsync<GetCurrencyAccountTransactionsResponse>($"api/CurrencyAccount/{id}/Transactions");
    
    // public async Task<Result<GetCurrencyAccountTransactionsResponse>> GetCurrencyAccountTransactionsAsync(Guid id, DateTime startDate, DateTime endDate)
    //     => await GetAsync<GetCurrencyAccountTransactionsResponse>($"api/CurrencyAccount/{id}/Transactions?startDate={startDate.ToString("yyyy-MM-dd")}&endDate={endDate.ToString("yyyy-MM-dd")}");

    #endregion
}