using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidLengthUserNameException(string firstName, string lastName) : MoneyMinderException($"First Name: '{firstName}' & Last Name: '{lastName}' are too long.");