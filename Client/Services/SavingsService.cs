using System.Net.Http.Formatting;
using System.Net.Http.Json;
using Client.Models;
using Client.Models.ReadModels;
using Client.Models.Requests.SavingsPortfolios.Commands;
using Client.Models.Responses.Savings;
using Client.Services.Interfaces;
using MoneyMinderClient.Models;

namespace Client.Services;

public class SavingsService : ISavingsService
{
    private readonly HttpClient _httpClient;
    
    public SavingsService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Auth");
    }
    
    public async Task<Result> PutSavings(CreateSavingsPortfolioRequest request)
    {
        Console.WriteLine($"Request: {request.Name}.");
        
        var responseMessage = await _httpClient.PutAsJsonAsync("api/Savings/", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }
  
    public async Task<Result> PostSavingsName(ChangeSavingsNameRequest request)
    {
        Console.WriteLine($"Request: {request.Name}.");
        
        var responseMessage = await _httpClient.PostAsJsonAsync("api/Savings/name", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };;
    }

    public async Task<Result> PostSavingsPlannedAmount(ChangeSavingsPlannedAmountRequest request)
    {
        Console.WriteLine($"Request: {request.Id}    {request.PlannedAmount}.");
        
        var responseMessage = await _httpClient.PostAsJsonAsync("api/Savings/PlannedAmount", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };;
    }

    public async Task<Result> DeleteSavings(DeleteSavingsPortfolioRequest request)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/Savings/");
        
        httpRequest.Content = new ObjectContent<DeleteSavingsPortfolioRequest>(request, new JsonMediaTypeFormatter());
        
        var responseMessage = await _httpClient.SendAsync(httpRequest);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };;
    }

    public async Task<Result> PostTransaction(ProcessSavingsTransactionRequest request)
    {
        Console.WriteLine($"Request: {request.Name}.");
        
        var responseMessage = await _httpClient.PostAsJsonAsync("api/Savings/transaction", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public async Task<Result<GetAllSavingsDetailsResponse>> GetAllSavingsDetails()
    {
        var responseMessage = await _httpClient.GetAsync($"api/Savings/");
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<SavingsPortfolioModel>>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true, Response = new (response)};
    }

    public async Task<Result<GetSavingsPortfolioIdByNameResponse>> GetIdByName(string name)
    {
        var responseMessage = await _httpClient.GetAsync($"api/Savings/id/{name}"); 
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<Guid>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true, Response = new (response)};
    }

    public async Task<Result<GetSavingsNamesResponse>> GetSavingsNames()
    {
        var responseMessage = await _httpClient.GetAsync($"api/Savings/names");
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<SavingsPortfolioNameModel>>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true, Response = new (response)};
    }

    public async Task<Result<GetSavingsPortfolioResponse>> GetSavingsPortfolio(Guid id)
    {
        var responseMessage = await _httpClient.GetAsync($"api/Savings/{id}");
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<SavingsPortfolioModel>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true, Response = new (response)};
    }
}