using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Infrastructure.EF.ReadServices;

public class CurrencyAccountReadService : ICurrencyAccountReadService
{
    public bool CheckUnique(CurrencyAccountName name)
    {
        throw new NotImplementedException();
    }
}