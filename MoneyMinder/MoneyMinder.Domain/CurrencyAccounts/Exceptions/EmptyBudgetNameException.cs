using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class EmptyBudgetNameException() : MoneyMinderException("Budget name cannot be empty.");
