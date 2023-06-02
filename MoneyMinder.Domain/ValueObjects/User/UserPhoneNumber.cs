using System.Text.RegularExpressions;
using MoneyMinder.Domain.Exceptions;

namespace MoneyMinder.Domain.ValueObjects.User;

public record UserPhoneNumber
{
    private Regex codeRegex = new(@"^\+\d{2,4}$");
    private Regex numberRegex = new(@"^\d{4,11}$");
    
    public string PhoneNumber { get; }
    public string Code { get; }
    
    public UserPhoneNumber(string code, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new InvalidUserPhoneNumberException($"{code} {phoneNumber}");
        }

        if (!codeRegex.IsMatch(code))
        {
            throw new InvalidUserPhoneNumberException($"{code} {phoneNumber}");
        }

        if (!numberRegex.IsMatch(phoneNumber))
        {
            throw new InvalidUserPhoneNumberException($"{code} {phoneNumber}");
        }

        Code = code;
        PhoneNumber = phoneNumber;
    }

    public static UserPhoneNumber Create(string value)
    {
        var splittedValue =value.Split(' ');
        
        if(splittedValue.Length != 2)
        {
            throw new InvalidUserPhoneNumberException(value);
        }

        return new UserPhoneNumber(splittedValue.First(), splittedValue.Last());
    }

    public override string ToString()
        => $"{Code} {PhoneNumber}";
}