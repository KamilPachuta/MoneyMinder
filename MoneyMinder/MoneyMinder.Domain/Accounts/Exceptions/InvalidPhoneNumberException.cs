using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidPhoneNumberException(string number) : MoneyMinderException($"Phone number: '{number}' is invalid.");