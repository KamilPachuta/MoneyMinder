using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.SavingsAccounts.Exceptions;

public sealed class SavingsAccountAlreadyExistException(string name)
    : MoneyMinderException($"Savings account with name: '{name}' already exist.");
