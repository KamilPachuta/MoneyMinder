using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InvalidLengthBudgetNameException(string name) : MoneyMinderException($"Budget name: '{name}' is not between 1-30 characters.");
