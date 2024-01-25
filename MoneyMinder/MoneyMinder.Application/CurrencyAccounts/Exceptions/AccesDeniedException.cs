using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

internal sealed class AccesDeniedException : MoneyMinderException
{
    public Guid AccountId { get; }
    public Guid CurrencyAccountId { get; }

    public AccesDeniedException(Guid accountId, Guid currencyAccountId)
        : base($"The account with ID: '{accountId}' is not the owner of the currency account with ID: '{currencyAccountId}'. ")
    {
        AccountId = accountId;
        CurrencyAccountId = currencyAccountId;
    }
}