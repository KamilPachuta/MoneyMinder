using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class EmptyCurrencyAccountNameException()
    : MoneyMinderException("Currency account name cannot be empty.");
