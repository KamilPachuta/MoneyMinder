using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed  class EmptyUserPhoneNumberException() : MoneyMinderException("Phone number cannot be empty.");
