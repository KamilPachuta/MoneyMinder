using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AccountEmail
{
    public string Value { get; set; }

    public AccountEmail(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyAccountEmailExpection();
        }

        if (value.Length > 255)
        {
            throw new InvalidLengthAccountEmailExpcetion(value);
        }
        
        Value = value;
    }
    
    public static implicit operator string(AccountEmail value)
        => value.Value; 

    public static implicit operator AccountEmail(string value)
        => new(value);
    
    //Flunet Validation?
}