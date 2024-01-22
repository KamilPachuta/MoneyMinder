using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Infrastructure.EF.Repositories;

public class CurrencyAccountRepository : ICurrencyAccountRepository
{
    public Task<CurrencyAccount> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(CurrencyAccount currencyAccount)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CurrencyAccount currencyAccount)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(CurrencyAccount currencyAccount)
    {
        throw new NotImplementedException();
    }
}