using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Application.CurrencyAccounts.Services;

public interface ICurrencyAccountReadService
{
    bool CheckUnique(CurrencyAccountName name);
}