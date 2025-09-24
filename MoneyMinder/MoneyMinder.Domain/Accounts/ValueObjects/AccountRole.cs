using MoneyMinder.Domain.Accounts.Enums;
using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public class AccountRole
{
    public Role Role { get; }

    public AccountRole(Role role)
    {
        if ((role is not Role.User) && (role is not Role.Admin))
        {
            throw new InvalidAccountRoleException(role);
        }
        
        Role = role;
    }
}