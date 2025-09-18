using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AccountEmail
{
    public string Email { get; set; }

    public AccountEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new EmptyAccountEmailException();
        }

        if (email.Length > 255)
        {
            throw new InvalidLengthAccountEmailException(email);
        }
        
        Email = email;
    }
    
    public static implicit operator string(AccountEmail email)
        => email.Email; 

    public static implicit operator AccountEmail(string email)
        => new(email);
    
}