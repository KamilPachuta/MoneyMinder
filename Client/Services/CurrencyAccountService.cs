using System.Net.Http.Formatting;
using System.Net.Http.Json;
using Client.Models.ReadModels;
using Client.Models.Requests.CurrencyAccount.Commands;
using Client.Models.Responses;
using Client.Services.Interfaces;
using MoneyMinder.API.Requests.CurrencyAccounts;
using MoneyMinderClient.Models;

namespace Client.Services;

public class CurrencyAccountService : ICurrencyAccountService
{
    private readonly HttpClient _httpClient;

    public CurrencyAccountService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Auth");
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
    
    public async Task<Result> DeleteCurrencyAccount(DeleteCurrencyAccountRequest request)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/CurrencyAccount");
        
        httpRequest.Content = new ObjectContent<DeleteCurrencyAccountRequest>(request, new JsonMediaTypeFormatter());
        
        var responseMessage = await _httpClient.SendAsync(httpRequest);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new()
            {
                $"Status Code: {responseMessage.StatusCode}", 
                $"Content: {await responseMessage.Content.ReadAsStringAsync()}"
            } };
        }
        
        return new (){ Succeeded = true };
    }
    
    
    public async Task<Result> PostIncome(AddIncomeRequest request)
    {
        Console.WriteLine($"Request:\nId: {request.Id.ToString()},\nName:{request.Name}.");
        
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/Income", request);
        
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
    
    
    public async Task<Result> PostPayment(AddPaymentRequest request)
    {
        Console.WriteLine($"Request:\nId: {request.Id.ToString()},\nName:{request.Name}.");

        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/Payment", request);
        
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

    public async Task<Result> EditMonthlyIncome(EditMonthlyIncomeRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/MonthlyIncome", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public async Task<Result> DeleteMonthlyIncome(RemoveMonthlyIncomeRequest request)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/CurrencyAccount/monthlyIncome");
        
        httpRequest.Content = new ObjectContent<RemoveMonthlyIncomeRequest>(request, new JsonMediaTypeFormatter());
        
        var responseMessage = await _httpClient.SendAsync(httpRequest);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }
    
    public async Task<Result> AcceptMonthlyIncome(AcceptMonthlyIncomeRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/MonthlyIncome/accept", request);
        
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
    
    public async Task<Result> EditMonthlyPayment(EditMonthlyPaymentRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/MonthlyPayment", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public async Task<Result> DeleteMonthlyPayment(RemoveMonthlyPaymentRequest request)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/CurrencyAccount/monthlyPayment");
        
        httpRequest.Content = new ObjectContent<RemoveMonthlyPaymentRequest>(request, new JsonMediaTypeFormatter());
        
        var responseMessage = await _httpClient.SendAsync(httpRequest);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }

    public async Task<Result> AcceptMonthlyPayment(AcceptMonthlyPaymentRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/MonthlyPayment/accept", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }
    
    
    public async Task<Result> ConvertTo(ConvertCurrencyToRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/Convert/to", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }
    
    public async Task<Result> ConvertFrom(ConvertCurrencyFromRequest request)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/CurrencyAccount/Convert/from", request);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Status Code: {responseMessage.StatusCode}" + $"Content: {await responseMessage.Content.ReadAsStringAsync()}");
            return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
        }
        
        return new (){ Succeeded = true };
    }
    
    
    
    
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
        
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<MonthlyTransactionModel>>();
        
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
}