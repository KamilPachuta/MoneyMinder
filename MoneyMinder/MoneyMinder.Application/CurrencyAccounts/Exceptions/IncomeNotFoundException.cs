using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

internal sealed class IncomeNotFoundException(Guid id) 
    : MoneyMinderException($"Income with ID: '{id}' does not exist.");