using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Authentication;
using MoneyMinderClient.Services.Interfaces;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinderClient.Services;

public class CurrencyAccountService : ICurrencyAccountService
{
    private readonly HttpClient _httpClient;

    public CurrencyAccountService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Auth");

    }
    
    
    #region Commands
    
    #endregion
    
    #region Queries
    
    public async Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNamesAsync()
    {
        var responseMessage = await _httpClient.GetAsync("api/CurrencyAccount/Names");
        var content = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            return Result<GetCurrencyAccountNamesResponse>.Failure(
                $"Status Code: {responseMessage.StatusCode}",
                $"Content: {content}"
            );
        }

        var response = JsonSerializer.Deserialize<GetCurrencyAccountNamesResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (response == null)
        {
            return Result<GetCurrencyAccountNamesResponse>.Failure(
                "Response is null.",
                $"Status Code: {responseMessage.StatusCode}",
                $"Content: {content}"
            );
        }

        return Result<GetCurrencyAccountNamesResponse>.Success(response);
        
    }
    
    #endregion
}