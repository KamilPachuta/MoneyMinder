using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

internal sealed class CurrencyAccountNotFoundException(Guid id)
    : MoneyMinderException($"Currency Account with ID: '{id}' was not found.");
