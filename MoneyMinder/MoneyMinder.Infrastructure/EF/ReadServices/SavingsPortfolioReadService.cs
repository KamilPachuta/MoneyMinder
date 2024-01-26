using MoneyMinder.Application.Savings.Services;
using MoneyMinder.Domain.Repository;
using MoneyMinder.Domain.SavingsPortfolios.ValueObjects;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.EF.ReadServices;

internal sealed class SavingsPortfolioReadService : ISavingsPortfolioReadService
{
    private readonly IAccountRepository _repository;


    public SavingsPortfolioReadService(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> CheckUnique(Guid accountId, SavingsPortfolioName name)
    {
        var account = await _repository.GetAsync(accountId);
        
        return account.SavingsPortfolios.Exists(sp => sp.Name == name);
    }

    public async Task<bool> CheckOwner(Guid accountId, Guid savingsPortfolioId)
    {
        var account = await _repository.GetAsync(accountId);
        
        return !account.SavingsPortfolios.Exists(sp => sp.Id == savingsPortfolioId);
    }
    
    
    // public async Task<bool> CheckUnique(Guid accountId, CurrencyAccountName name)
    // {
    //     var account = await _repository.GetAsync(accountId);
    //
    //     return account.CurrencyAccounts.Exists(ca => ca.Name == name);
    // }
    //
    // public async Task<bool> CheckOwner(Guid accountId, Guid currencyAccountId)
    // {
    //     var account = await _repository.GetAsync(accountId);
    //
    //     return !account.CurrencyAccounts.Exists(ca => ca.Id == currencyAccountId);
    // }
}