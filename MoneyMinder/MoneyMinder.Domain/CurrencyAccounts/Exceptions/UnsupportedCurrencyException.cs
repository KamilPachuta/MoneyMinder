using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class UnsupportedCurrencyException(string currency) : MoneyMinderException($"Currency: '{currency}' is not supported.");