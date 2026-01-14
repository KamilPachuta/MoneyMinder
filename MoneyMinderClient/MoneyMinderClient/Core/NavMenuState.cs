using System.Net;
using Microsoft.AspNetCore.Components;
using MoneyMinderClient.Services;
using MoneyMinderClient.Services.Interfaces;

namespace MoneyMinderClient.Core;

public class NavMenuState
{
    private ICurrencyAccountService _currencyService;
    private ISavingsAccountService _savingsService;
    private IAccountService _accountService;
    private NavigationManager _navigationManager;

    public NavMenuState(ICurrencyAccountService currencyService, ISavingsAccountService savingsService, IAccountService accountService, NavigationManager navigationManager)
    {
        _currencyService = currencyService;
        _savingsService = savingsService;
        _accountService = accountService;
        _navigationManager = navigationManager;
    }

    public IReadOnlyList<string> CurrencyAccountNames => _currencyAccountNames;
    private List<string> _currencyAccountNames = new(); 
    
    public IReadOnlyList<string> SavingsAccountNames => _savingsAccountNames;
    private List<string> _savingsAccountNames = new();
    

    public event Action? OnChange;

    public async Task LoadCurrencyAsync()
    {
        var responseCurrencyAccounts = await _currencyService.GetCurrencyAccountNamesAsync();
        
        if (responseCurrencyAccounts.Succeeded)
        {
            _currencyAccountNames = responseCurrencyAccounts.Response.Names.ToList();
        }
        else
        {
            if (responseCurrencyAccounts.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _accountService.LogoutAsync();
                _navigationManager.NavigateTo("/login/", true);
            }
            
        }
        
        
        Notify();
    }

    public async Task RefreshCurrencyAsync()
    {
        await LoadCurrencyAsync();
    }

    public async Task LoadSavingsAsync()
    {
        var responseSavings = await _savingsService.GetSavingsAccountNames();

        if (responseSavings.Succeeded)
        {
            _savingsAccountNames = responseSavings.Response.Names.ToList();
        }
        
        
        Notify();
    }

    public async Task RefreshSavingsAsync()
    {
        await LoadSavingsAsync();
    }
    
    private void Notify() => OnChange?.Invoke();
}
