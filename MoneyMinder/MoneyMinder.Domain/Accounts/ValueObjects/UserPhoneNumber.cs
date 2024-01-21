using System.Text.RegularExpressions;
using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record UserPhoneNumber
{
    private Regex _codeRegex = new(@"^\+\d{2,4}$");
    private Regex _numberRegex = new(@"^\d{4,11}$");
    
    public string Code { get; }
    public string Number { get; }

    public UserPhoneNumber(string code, string number)
    {
        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(number))
        {
            throw new EmptyUserPhoneNumberException();
        }

        if (!_codeRegex.IsMatch(code))
        {
            throw new InvalidPhoneCodeException(code);
        }

        if (!_numberRegex.IsMatch(number))
        {
            throw new InvalidPhoneNumberException(number);
        }
        
        
        Code = code;
        Number = number;
    }
    
    public static UserPhoneNumber Create(string value)
    {
        var splittedValue =value.Split('-');
        
        if(splittedValue.Length != 2)
        {
            throw new InvalidUserPhoneNumberException(value);
        }

        return new UserPhoneNumber(splittedValue.First(), splittedValue.Last());
    }

    public override string ToString()
        => $"{Code}-{Number}";
}


/*
 * 
 
 private Regex codeRegex = new(@"^\+\d{2,4}$");
    private Regex numberRegex = new(@"^\d{4,11}$");
    
    public string Code { get; }
    public string PhoneNumber { get; }

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
        var splittedValue =value.Split('-');
        
        if(splittedValue.Length != 2)
        {
            throw new InvalidUserPhoneNumberException(value);
        }

        return new UserPhoneNumber(splittedValue.First(), splittedValue.Last());
    }

    public override string ToString()
        => $"{Code}-{PhoneNumber}";
}
 
 
 
 
 
 
 */