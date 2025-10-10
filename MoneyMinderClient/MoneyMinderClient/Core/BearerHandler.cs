using Blazored.LocalStorage;

namespace MoneyMinderClient.Core;

public class BearerHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorageService;
    
    public BearerHandler(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _localStorageService.GetItemAsStringAsync("Token");

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Add("Authorization", $"Bearer {token}");
        }

        return await base.SendAsync(request, cancellationToken);
    }
}