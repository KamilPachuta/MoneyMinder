using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.Exceptions;

internal sealed class InvalidLengthSavingsAccountNameException(string name)
    : MoneyMinderException($"Savings account name: '{name}' must be between 3 and 50 characters long.");
