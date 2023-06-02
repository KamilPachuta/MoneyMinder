namespace MoneyMinder.Domain.Exceptions;

public class CastingUserAddressException : Exception
{
    public string Address { get; }

    public CastingUserAddressException(string address) : base($"'{address}' is invalid address.")
    {
        Address = address;
    }
}