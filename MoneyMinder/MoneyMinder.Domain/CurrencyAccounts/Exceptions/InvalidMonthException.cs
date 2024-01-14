using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InvalidMonthException(DateTime date) : MoneyMinderException($"Invalid month: '{date}'. The month must be current or next.");
