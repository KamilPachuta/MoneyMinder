using MoneyMinder.Domain.CurrencyAccounts;

namespace MoneyMinder.Domain.Repositories;

public interface ICurrencyAccountRepository
{
    Task<CurrencyAccount> GetAsync(Guid id);
    Task AddAsync(CurrencyAccount currencyAccount);
    Task UpdateAsync(CurrencyAccount currencyAccount);
    Task DeleteAsync(CurrencyAccount currencyAccount);
}