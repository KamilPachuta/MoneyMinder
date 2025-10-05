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
    // public async Task<Result> PostSavingsAccountAsync(CreateSavingsAccountRequest request)
    // {
    //     var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount", request);
    //     
    //     if (!responseMessage.IsSuccessStatusCode)
    //     {
    //         return Result.Failure(
    //             $"Status Code: {responseMessage.StatusCode}",
    //             $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
    //     }
    //     
    //     return Result.Success();
    // }
    
    

    #endregion
    
    #region Queries

    

    public async Task<Result<GetSavingsAccountNamesResponse>> GetSavingsAccountNames()
        => await GetAsync<GetSavingsAccountNamesResponse>("api/SavingsAccount/Names");
    // public async Task<Result<GetSavingsAccountNamesResponse>> GetSavingsAccountNames()
    // {
    //     var responseMessage = await _httpClient.GetAsync("api/SavingsAccount/Names");
    //     var content = await responseMessage.Content.ReadAsStringAsync();
    //
    //     if (!responseMessage.IsSuccessStatusCode)
    //     {
    //         return Result<GetSavingsAccountNamesResponse>.Failure(
    //             $"Status Code: {responseMessage.StatusCode}",
    //             $"Content: {content}"
    //         );
    //     }
    //
    //     var response = JsonSerializer.Deserialize<GetSavingsAccountNamesResponse>(content, new JsonSerializerOptions
    //     {
    //         PropertyNameCaseInsensitive = true
    //     });
    //
    //     if (response == null)
    //     {
    //         return Result<GetSavingsAccountNamesResponse>.Failure(
    //             "Response is null.",
    //             $"Status Code: {responseMessage.StatusCode}",
    //             $"Content: {content}"
    //         );
    //     }
    //
    //     return Result<GetSavingsAccountNamesResponse>.Success(response);
    // }
    
    

    
    #endregion

}