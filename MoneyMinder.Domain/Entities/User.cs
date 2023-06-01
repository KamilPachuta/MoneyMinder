using MoneyMinder.Domain.ValueObjects.User;

namespace MoneyMinder.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    private UserLogin _login;
    private string _passwordHash;
    private string _email;
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    //private Gender _gender;
    private DateTime _birthDate;
    private string _address;

    private readonly List<BankAccount> _bankAccounts;
    //private readonly List<SavingsAccount> _savingsAccounts;
    //private readonly List<CryptoAccount> _cryptoAccounts;

    internal User(UserLogin login)
    {

        _login = login;
    }

}