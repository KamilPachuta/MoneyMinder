using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AccountRole // enum?
{
    public Role Role { get; set; }

    public AccountRole(Role role)
    {
        if ((role is not Role.User) && (role is not Role.Admin))
        {
            throw new InvalidAccountRoleExcpetion(role);
        }
        
        Role = role;
    }
    
    
}