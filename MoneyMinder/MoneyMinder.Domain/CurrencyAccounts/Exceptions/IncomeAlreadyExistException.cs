using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class IncomeAlreadyExistException(Income income) : MoneyMinderException($"Income: '{income}' already exist.");
