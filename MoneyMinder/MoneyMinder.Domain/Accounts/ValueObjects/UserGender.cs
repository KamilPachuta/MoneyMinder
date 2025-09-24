using MoneyMinder.Domain.Accounts.Enums;
using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public class UserGender
{
    public Gender Gender { get; }

    public UserGender(Gender gender)
    {
        if ((gender is not Gender.Men) && (gender is not Gender.Women))
        {
            throw new InvalidUserGenderException(gender);
        }
        
        Gender = gender;
    }
    
    public static implicit operator Gender(UserGender gender)
        => gender.Gender; 

    public static implicit operator UserGender(Gender gender)
        => new(gender);
}