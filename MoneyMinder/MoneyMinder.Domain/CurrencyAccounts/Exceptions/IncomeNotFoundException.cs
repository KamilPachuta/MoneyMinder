using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class IncomeNotFoundException(Guid id) 
    : MoneyMinderException($"Income with ID: '{id}' does not exist.");
