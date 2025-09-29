using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

internal sealed class CurrencyAccountOwnershipException(Guid accountId, Guid currencyAccountId) 
    : MoneyMinderException($"The account with ID: '{accountId}' is not the owner of the currency account with ID: '{currencyAccountId}'.");