using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace MoneyMinderClient.Services.Authentication;

public class AppAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private ClaimsPrincipal _anonymous => new ClaimsPrincipal(new ClaimsIdentity());

    public AppAuthenticationStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsStringAsync("Token");
        if (string.IsNullOrWhiteSpace(token))
            return new AuthenticationState(_anonymous);

        var handler = new JwtSecurityTokenHandler();
        if (!handler.CanReadToken(token))
            return new AuthenticationState(_anonymous);

        var jwt = handler.ReadJwtToken(token);
        var identity = new ClaimsIdentity(jwt.Claims, "jwt");
        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    public void NotifyUserAuthentication() 
        => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    public void NotifyUserLogout()
        => NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
}