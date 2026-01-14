using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using MoneyMinderClient.Core;
using MoneyMinderClient.Services.Interfaces;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderClient.Services.Abstractions;

public abstract class BaseService
{
    private readonly HttpClient _httpClient;
    private readonly IAccountService _accountService;

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
                return Result.Failure(response.StatusCode,
                    $"Status Code: {response.StatusCode}",
                    $"Content: {content}");
            }

            return Result.Success(response.StatusCode);
        }
        catch (HttpRequestException ex)
        {
            return Result.Failure(HttpStatusCode.InternalServerError, "HTTP request failed", ex.Message);
        }
        catch (Exception ex)
        {
            return Result.Failure(HttpStatusCode.InternalServerError, "Unexpected error", ex.Message);
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
    
    protected async Task<Result<TResponse>> PostReportAsync<TRequest, TResponse>(
        string url,
        TRequest? request = null)
        where TRequest : class
        where TResponse : class, IResponse
    {
        try
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(url, request);

            var content = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
                return Result<TResponse>.Failure(
                    httpResponse.StatusCode,
                    $"Status Code: {httpResponse.StatusCode}",
                    $"Content: {content}");

            if (string.IsNullOrWhiteSpace(content))
                return Result<TResponse>.Failure(
                    httpResponse.StatusCode,
                    "Response is empty.",
                    $"Status Code: {httpResponse.StatusCode}");

            var dto = JsonSerializer.Deserialize<TResponse>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return dto is not null
                ? Result<TResponse>.Success(httpResponse.StatusCode, dto)
                : Result<TResponse>.Failure(httpResponse.StatusCode, "Deserialization returned null.", $"Content: {content}");
        }
        catch (HttpRequestException ex)
        {
            return Result<TResponse>.Failure(HttpStatusCode.InternalServerError, "HTTP request failed", ex.Message);
        }
        catch (Exception ex)
        {
            return Result<TResponse>.Failure(HttpStatusCode.InternalServerError, "Unexpected error", ex.Message);
        }
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
                    responseMessage.StatusCode,
                    $"Status Code: {responseMessage.StatusCode}",
                    $"Content: {content}");

            var response = JsonSerializer.Deserialize<TResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (response == null)
                return Result<TResponse>.Failure(
                    responseMessage.StatusCode,
                    "Response is null.",
                    $"Status Code: {responseMessage.StatusCode}",
                    $"Content: {content}");

            return Result<TResponse>.Success(responseMessage.StatusCode, response);

        }
        catch (HttpRequestException ex)
        {
            return Result<TResponse>.Failure(HttpStatusCode.InternalServerError, "HTTP request failed", ex.Message);
        }
        catch (Exception ex)
        {
            return Result<TResponse>.Failure(HttpStatusCode.InternalServerError, "Unexpected error", ex.Message);
        }
        
    }
}