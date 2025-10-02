using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

public sealed class CurrencyAccountAlreadyExistException(string name) 
    : MoneyMinderException($"Currency account with name: '{name}' already exists.");