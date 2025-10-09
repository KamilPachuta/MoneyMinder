using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Abstractions;
using MoneyMinderClient.Services.Interfaces;
using MoneyMinderContracts.Requests.SavingsAccounts;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinderClient.Services;

public class SavingsAccountService : BaseService, ISavingsAccountService
{
    private readonly HttpClient _httpClient;

    public SavingsAccountService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
    }
    
    #region Commands
    public async Task<Result> PostSavingsAccountAsync(CreateSavingsAccountRequest request)
        => await SendAsync("api/SavingsAccount", HttpMethod.Post, request);
    
    public async Task<Result> PatchSavingsAccountAsync(ChangeSavingsAccountNameRequest request)
        => await SendAsync("api/SavingsAccount", HttpMethod.Patch, request);
    
    public async Task<Result> DeleteSavingsAccountAsync(DeleteSavingsAccountRequest request)
        => await SendAsync("api/SavingsAccount", HttpMethod.Delete, request);
   
    
    

    #endregion
    
    #region Queries

    

    public async Task<Result<GetSavingsAccountNamesResponse>> GetSavingsAccountNames()
        => await GetAsync<GetSavingsAccountNamesResponse>("api/SavingsAccount/Names");

    public async Task<Result<GetSavingsAccountDetailsResponse>> GetSavingsAccountDetailsAsync(string name)
        => await GetAsync<GetSavingsAccountDetailsResponse>($"api/SavingsAccount/Details/{name}");    
    
    public async Task<Result<GetSavingsAccountsDetailsResponse>> GetSavingsAccountsDetailsAsync()
        => await GetAsync<GetSavingsAccountsDetailsResponse>("api/SavingsAccount/Details");

    #endregion

}