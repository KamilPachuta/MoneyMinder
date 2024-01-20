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
    
    //Flunet Validation?
}