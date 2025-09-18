using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidUserPhoneNumberException(string phoneNumber) : MoneyMinderException($"Phone number: '{phoneNumber}' has incorrect format.");
