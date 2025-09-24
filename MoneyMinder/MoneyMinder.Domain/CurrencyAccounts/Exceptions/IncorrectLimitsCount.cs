using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class IncorrectLimitsCount() : MoneyMinderException("Limits must contain all categories");
