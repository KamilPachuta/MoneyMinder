using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Abstractions;
using MoneyMinderClient.Services.Authentication;
using MoneyMinderClient.Services.Interfaces;
using MoneyMinderContracts.Requests.Accounts;
using MoneyMinderContracts.Responses.Accounts;

namespace MoneyMinderClient.Services;

public class AccountService : BaseService, IAccountService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AppAuthenticationStateProvider _authenticationStateProvider;
    private readonly JsonSerializerOptions _jsonOptions;

    public AccountService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorage, AppAuthenticationStateProvider authenticationStateProvider)
        : base(httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Auth");
        _localStorage = localStorage;
        _authenticationStateProvider = authenticationStateProvider;
        _jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    
    #region Commands
    
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

    public async Task<Result> RegisterAsync(CreateUserRequest request)
        => await SendAsync("api/Account/User", HttpMethod.Post, request);
    

    #endregion
    
    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("Token");
        _authenticationStateProvider.NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<bool> CheckAuthenticationAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User.Identity?.IsAuthenticated ?? false;
    }
    
    #region Queries
    
    public async Task<string> GetNameAsync()
    {
        var token = await _localStorage.GetItemAsStringAsync("Token");

        if (!string.IsNullOrEmpty(token))
        {
            var handler = new JwtSecurityTokenHandler();
                
            JwtSecurityToken? jsonToken = null;

            if (handler.CanReadToken(token))
            {
                jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            }

            if (jsonToken != null)
            {
                return jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "";
            }
        }

        return "";

    }
    #endregion


}
