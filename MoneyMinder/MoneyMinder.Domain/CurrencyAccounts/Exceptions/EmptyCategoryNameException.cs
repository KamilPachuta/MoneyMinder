using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class EmptyCategoryNameException() : MoneyMinderException("Category name cannot be empty.");
