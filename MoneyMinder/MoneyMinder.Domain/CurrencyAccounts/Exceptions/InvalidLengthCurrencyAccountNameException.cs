using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InvalidLengthCurrencyAccountNameException(string name) 
    : MoneyMinderException($"Currency account name: '{name}' must be between 3 and 50 characters long.");