using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class BalanceNotFoundException(DefinedCurrency currency) 
    : MoneyMinderException($"Balance with currency: '{currency}' was not found");
