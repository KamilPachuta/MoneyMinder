using MoneyMinder.Domain.ValueObjects.User;

namespace MoneyMinder.Domain.Entities;

public class User
{
    public UserLogin Login { get; private set; } // brak edycji -- natural Key - do encji dodawać Id ale tu nie potrzebne 

    private string _passwordHash;
    private UserEmail _email;
    private UserName _name; // brak edycji
    private UserPhoneNumber _phoneNumber;
    //private Gender _gender; // brak edycji
    private UserBirthDate _birthDate; //brak edycji
    private UserAddress _address;

    private readonly List<BankAccount> _bankAccounts;
    
    //private readonly List<SavingsAccount> _savingsAccounts;
    //private readonly List<CryptoAccount> _cryptoAccounts;

    internal User(UserLogin login, UserEmail email, UserName name, UserPhoneNumber phoneNumber, UserBirthDate birthDate, UserAddress address)
    {
        Login = login;
        _email = email;
        _name = name;
        _phoneNumber = phoneNumber;
        _birthDate = birthDate;
        _address = address;
    }

}