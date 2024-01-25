using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Application.CurrencyAccounts.Services;

public interface ICurrencyAccountReadService
{
    Task<bool> CheckUnique(Guid accountId, CurrencyAccountName name);
    Task<bool> CheckOwner(Guid accountId, Guid currencyAccountId);
}