using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Abstractions;

public abstract class Transaction : Entity
{
    public TransactionName Name { get; }
    public DateTime Date { get; }
    public Currency Currency { get; }
    public Amount Amount { get; }


    protected Transaction()
    {
    }

    protected Transaction(TransactionName name, DateTime date, Currency currency, Amount amount)
    {
        if (date.Kind != DateTimeKind.Utc)
        {
            date = date.ToUniversalTime();
        }
        
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
    }
    
    // protected Transaction(Guid id, TransactionName name, DateTime date, Currency currency, Amount amount)
    //     : base(id)
    // {
    //     Name = name;
    //     Date = date;
    //     Currency = currency;
    //     Amount = amount;
    // }

    public override string ToString()
    {
        return $"TransactionName: '{Name.Name}'\nTransactionDate: '{Date}'\nCurrency: '{Currency}'\nAmount: '{Amount}'\n";
    }
    
    public static bool operator ==(Transaction? first, Transaction? second)
     {
         return first is not null && second is not null && first.Equals(second);
     }
     
     public static bool operator !=(Transaction? first, Transaction? second)
     {
         return !(first == second);
     }
     
     public bool Equals(Entity? other)
     {
         if (other is null)
         {
             return false;
         }

         return other.Id == Id;
     }
     public override bool Equals(object? obj)
     {
         if (obj is null)
         {
             return false;
         }

         if (obj.GetType() != GetType())
         {
             return false;
         }

         if (obj is not Entity entity)
         {
             return false;
         }
         
         return entity.Id == Id;
     }
     public override int GetHashCode()
     {
         return Id.GetHashCode();
     }
    
}
