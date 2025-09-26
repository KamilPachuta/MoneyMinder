using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Application.CurrencyAccounts.Services;

public interface ICurrencyAccountReadService
{
    Task<bool> CheckOwner(Guid accountId, Guid currencyAccountId);
    Task<bool> CheckUnique(Guid accountId, CurrencyAccountName name);
}