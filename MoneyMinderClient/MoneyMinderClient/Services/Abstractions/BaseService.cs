using System.Net.Http.Json;
using System.Text.Json;
using MoneyMinderClient.Core;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderClient.Services.Abstractions;

public abstract class BaseService
{
    private readonly HttpClient _httpClient;

    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Auth");
    }
    
    protected async Task<Result> SendAsync<TRequest>(
        string url, 
        HttpMethod method, 
        TRequest? request = null)
        where TRequest : class
    {
        try
        {
            HttpResponseMessage response = method.Method switch
            {
                "POST" => await _httpClient.PostAsJsonAsync(url, request),
                "PUT" => await _httpClient.PutAsJsonAsync(url, request),
                "PATCH" => await _httpClient.PatchAsJsonAsync(url, request),
                "DELETE" => await DeleteAsJsonAsync(url, request),
                _ => throw new NotSupportedException($"HTTP method {method} is not supported.")
            };

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Result.Failure(
                    $"Status Code: {response.StatusCode}",
                    $"Content: {content}");
            }

            return Result.Success();
        }
        catch (HttpRequestException ex)
        {
            return Result.Failure("HTTP request failed", ex.Message);
        }
        catch (Exception ex)
        {
            return Result.Failure("Unexpected error", ex.Message);
        }
    }
    
    private async Task<HttpResponseMessage> DeleteAsJsonAsync<TRequest>(string url, TRequest? request = null)
        where TRequest : class
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, url);

        if (request != null)
            httpRequest.Content = JsonContent.Create(request);

        return await _httpClient.SendAsync(httpRequest);
    }
    
    protected async Task<Result<TResponse>> GetAsync<TResponse>(string url)
        where TResponse : class, IResponse
    {
        try
        {
            var responseMessage = await _httpClient.GetAsync(url);
            var content = await responseMessage.Content.ReadAsStringAsync();

            if (!responseMessage.IsSuccessStatusCode)
                return Result<TResponse>.Failure(
                    $"Status Code: {responseMessage.StatusCode}",
                    $"Content: {content}");

            var response = JsonSerializer.Deserialize<TResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (response == null)
                return Result<TResponse>.Failure(
                    "Response is null.",
                    $"Status Code: {responseMessage.StatusCode}",
                    $"Content: {content}");

            return Result<TResponse>.Success(response);

        }
        catch (HttpRequestException ex)
        {
            return Result<TResponse>.Failure("HTTP request failed", ex.Message);
        }
        catch (Exception ex)
        {
            return Result<TResponse>.Failure("Unexpected error", ex.Message);
        }
        
    }
}