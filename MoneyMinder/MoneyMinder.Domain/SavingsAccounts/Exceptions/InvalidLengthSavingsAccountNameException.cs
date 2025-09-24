using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.Exceptions;

internal sealed class InvalidLengthSavingsAccountNameException(string name)
    : MoneyMinderException($"Savings account name: '{name}' is too long.");
