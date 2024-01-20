using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Accounts.Enum;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidAccountRoleExcpetion : MoneyMinderException
{
    public Role Role { get; set; }

    public InvalidAccountRoleExcpetion(Role role)
        : base($"Role: '{role}' is invalid.")
    {
        Role = role;
    }
}