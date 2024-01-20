using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidLengthAccountEmailExpcetion(string email) : MoneyMinderException($"Emial: '{email}' is too long.")
{
    
}