using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class BudgetNotFoundException() : MoneyMinderException("Budget for current month not found.");
