using System.Text.Json;
using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Interfaces;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinderClient.Services;

public class SavingsAccountService : ISavingsAccountService
{
    private readonly HttpClient _httpClient;

    public SavingsAccountService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Auth");
    }
    
    #region Commands
    
    #endregion
    
    #region Queries
    
    public async Task<Result<GetSavingsAccountNamesResponse>> GetSavingsAccountNames()
    {
        var responseMessage = await _httpClient.GetAsync("api/SavingsAccount/Names");
        var content = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            return Result<GetSavingsAccountNamesResponse>.Failure(
                $"Status Code: {responseMessage.StatusCode}",
                $"Content: {content}"
            );
        }

        var response = JsonSerializer.Deserialize<GetSavingsAccountNamesResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (response == null)
        {
            return Result<GetSavingsAccountNamesResponse>.Failure(
                "Response is null.",
                $"Status Code: {responseMessage.StatusCode}",
                $"Content: {content}"
            );
        }

        return Result<GetSavingsAccountNamesResponse>.Success(response);
    }
    
    #endregion

}