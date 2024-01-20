using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.Repository;

public interface ICurrencyAccountRepository
{
    Task<CurrencyAccount> GetAsync(Guid id);
    Task AddAsync(CurrencyAccount currencyAccount);
    Task UpdateAsync(CurrencyAccount currencyAccount);
    Task DeleteAsync(CurrencyAccount currencyAccount);
}