using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.Exceptions;

internal sealed class EmptySavingsAccountNameException()
    : MoneyMinderException("Savings Account Name cannot be empty.");
