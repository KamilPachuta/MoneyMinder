using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Abstractions;
using MoneyMinderClient.Services.Authentication;
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

    
    
    #endregion
    
    #region Queries

    

    public async Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNamesAsync()
        => await GetAsync<GetCurrencyAccountNamesResponse>("api/CurrencyAccount/Names");
    
    
    
    
    #endregion
}