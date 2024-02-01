using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Client.Models.ReadModels;
using Client.Models.Requests.CurrencyAccount.Commands;
using Client.Models.Responses;
using Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using MoneyMinder.API.Requests.CurrencyAccounts;
using MoneyMinderClient.Models;
using MoneyMinderClient.Services.Interfaces;

namespace Client.Services;

public class CurrencyAccountService : ICurrencyAccountService
{
    private readonly HttpClient _httpClient;
    private readonly IAccountService _accountService;


    public CurrencyAccountService(IHttpClientFactory httpClientFactory, IAccountService accountService)
    {
        _httpClient = httpClientFactory.CreateClient("Auth");
        _accountService = accountService;
    }
    //protected UriBuilder GenerateUriBuilder(string endpointPath) => new(_navigationManager.BaseUri + endpointPath);
    public async Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNames()
    {
        var responseMessage = await _httpClient.GetAsync("api/CurrencyAccount/names"); //.PostAsJsonAsync("api/Account", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<CurrencyAccountNameModel>>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true, Response = new (response)};
    }

    public async Task<Result<GetCurrencyAccountBalancesResponse>> GetCurrencyAccountBalances(Guid id)
    {
        var responseMessage = await _httpClient.GetAsync($"api/CurrencyAccount/{id}/balances"); //.PostAsJsonAsync("api/Account", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<BalanceModel>>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true, Response = new (response)};
    }

    public async Task<Result<GetCurrencyAccountTransactionsResponse>> GetCurrencyAccountTransactions(Guid id)
    {
        var responseMessage = await _httpClient.GetAsync($"api/CurrencyAccount/{id}/transactions"); //.PostAsJsonAsync("api/Account", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<TransactionModel>>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true, Response = new (response)};
    }

    public async Task<Result<GetMonthlyTransactionsResponse>> GetMonthlyTransactions(Guid id)
    {
        var responseMessage = await _httpClient.GetAsync($"api/CurrencyAccount/{id}/monthlyTransactions");
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<TransactionModel>>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true, Response = new (response)};
    }

    public async Task<Result<GetCurrencyAccountIdByNameResponse>> GetIdByName(string name)
    {
        var responseMessage = await _httpClient.GetAsync($"api/CurrencyAccount/id/{name}"); //.PostAsJsonAsync("api/Account", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        var response = await responseMessage.Content.ReadFromJsonAsync<Guid>();
        
        if (response == null)
        {
            return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        Console.WriteLine(response.ToString() + "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        return new (){ Succeeded = true, Response = new (response)};
    }

    public async Task<Result> PostCurrencyAccount(ChangeCurrencyAccountNameRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"StatusCode: '{responseMessage.StatusCode}'\nContent: '{await responseMessage.Content.ReadAsStringAsync()}'.");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true};
    }

    public async Task<Result> PostIncome(AddIncomeRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/Income", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            

            
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public async Task<Result> PostPayment(AddPaymentRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/Payment", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public async Task<Result> PutMonthlyIncome(AddMonthlyIncomeRequest request)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync("api/CurrencyAccount/MonthlyIncome", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }
    
    public async Task<Result> PutMonthlyPayment(AddMonthlyPaymentRequest request)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync("api/CurrencyAccount/MonthlyPayment", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public async Task<Result> DeleteIncome(RemoveIncomeRequest request)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/CurrencyAccount/income");
        
        httpRequest.Content = new ObjectContent<RemoveIncomeRequest>(request, new JsonMediaTypeFormatter());
        
        var responseMessage = await _httpClient.SendAsync(httpRequest);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public async Task<Result> DeletePayment(RemovePaymentRequest request)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/CurrencyAccount/payment");
        
        httpRequest.Content = new ObjectContent<RemovePaymentRequest>(request, new JsonMediaTypeFormatter());
        
        var responseMessage = await _httpClient.SendAsync(httpRequest);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public Task<Result> EditMonthlyIncome(EditMonthlyIncomeRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteMonthlyIncome(RemoveMonthlyIncomeRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Result> EditMonthlyPayment(EditMonthlyPaymentRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteMonthlyPayment(RemoveMonthlyPaymentRequest request)
    {
        throw new NotImplementedException();
    }


    public async Task<Result> PutCurrencyAccount(CreateCurrencyAccountRequest request)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync("api/CurrencyAccount", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"StatusCode: '{responseMessage.StatusCode}'\nContent: '{await responseMessage.Content.ReadAsStringAsync()}'.");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true};
    }
}