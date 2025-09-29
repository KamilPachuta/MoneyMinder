using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.SavingsAccounts.Exceptions;

internal sealed class SavingsAccountNotFoundException(Guid id)
    : MoneyMinderException($"The savings account with ID: '{id}' was not found.");
