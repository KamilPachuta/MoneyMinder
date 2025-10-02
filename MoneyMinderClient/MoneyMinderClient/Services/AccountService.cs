using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Authentication;
using MoneyMinderClient.Services.Interfaces;
using MoneyMinderContracts.Requests.Accounts;
using MoneyMinderContracts.Responses;

namespace MoneyMinderClient.Services;

public class AccountService : IAccountService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AppAuthenticationStateProvider _authenticationStateProvider;
    private readonly JsonSerializerOptions _jsonOptions;

    public AccountService(HttpClient httpClient, ILocalStorageService localStorage, AppAuthenticationStateProvider authenticationStateProvider)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _authenticationStateProvider = authenticationStateProvider;
        _jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    public async Task<Result<LoginResponse>> LoginAsync(LoginAccountRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/Account", request);
            if (!response.IsSuccessStatusCode)
                return Result<LoginResponse>.Failure(await response.Content.ReadAsStringAsync());

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>(_jsonOptions);
            if (loginResponse?.Token is null)
                return Result<LoginResponse>.Failure("Token not received from API");
            
            await _localStorage.SetItemAsStringAsync("Token", loginResponse.Token);
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", loginResponse.Token);

            _authenticationStateProvider.NotifyUserAuthentication();
            
            return Result<LoginResponse>.Success(loginResponse);
        }
        catch (Exception ex)
        {
            return Result<LoginResponse>.Failure(ex.Message);
        }
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("Token");
        _authenticationStateProvider.NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    // public async Task<string> GetTokenAsync() 
    //     => await _localStorage.GetItemAsStringAsync("Token");

}
