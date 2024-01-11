using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InvalidLengthCategoryNameException(string name) : MoneyMinderException($"Category name: '{name}' is not between 1-25 characters.");