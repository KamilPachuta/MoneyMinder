using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class DuplicateExpensesException(IEnumerable<Expense> Expenses) : MoneyMinderException($"Duplicate items exist in the expenses: '{Expenses}' collection.");