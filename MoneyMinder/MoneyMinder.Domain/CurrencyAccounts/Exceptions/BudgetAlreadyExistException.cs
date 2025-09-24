using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class BudgetAlreadyExistException() : MoneyMinderException("Budget for current month already exists.");
