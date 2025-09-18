using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidUserBirthDateException(DateTime date) : MoneyMinderException($"Incorrect birth date: '{date}'. User has to be over 18 years old.");
