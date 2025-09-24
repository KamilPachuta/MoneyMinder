using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InvalidBudgetDateException(DateTime date) 
    : MoneyMinderException($"Invalid budget date: '{date}'. The budget date must be for the current month.");