using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidPhoneCodeException(string code) : MoneyMinderException($"Phone code: '{code}' is invalid.");
