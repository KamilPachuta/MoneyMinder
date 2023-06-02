namespace MoneyMinder.Domain.Exceptions;

public class InvalidUserPhoneNumberException : Exception
{
    public string PhoneNumber { get; }

    public InvalidUserPhoneNumberException(string phoneNumber) : base($"Phone number: '{phoneNumber}' is invalid.")
    {
        PhoneNumber = phoneNumber;
    }
}