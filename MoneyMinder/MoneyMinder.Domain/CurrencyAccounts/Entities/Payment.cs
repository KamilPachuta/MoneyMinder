using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.Shared.Primitives;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Payment : Transaction
{
    public DefinedCategory Category { get; }
    
    public Payment(TransactionName name, TransactionDate date, DefinedCurrency currency, Amount amount, DefinedCategory? category) 
        : base(name, date, currency,amount)
    {
        Category = category ?? Shared.Enums.Category.Other;
        
        CheckAmount(amount);
    }
    
    private void CheckAmount(decimal amount)
    {
        if (amount >= 0)
        {
            throw new PositiveAmountException(amount);
        }
    }
}