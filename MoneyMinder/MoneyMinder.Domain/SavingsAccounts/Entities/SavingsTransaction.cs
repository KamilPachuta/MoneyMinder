using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.SavingsAccounts.Enums;
using MoneyMinder.Domain.SavingsAccounts.Exceptions;
using MoneyMinder.Domain.Shared.Enums;
using MoneyMinder.Domain.Shared.Exceptions;
using MoneyMinder.Domain.Shared.Primitives;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.SavingsAccounts.Entities;

public class SavingsTransaction : Transaction
{
    public TransactionType Type { get; }
    
    public SavingsTransaction(TransactionName name, DateTime date, Currency currency, Amount amount, TransactionType type) 
        : base(name, date, currency, amount)
    {
        CheckAmount(type, amount);
        Type = type;
    }

    private void CheckAmount(TransactionType type, Amount amount)
    {
        switch (type)
        {
            case TransactionType.Deposit:
                if (amount.Value <= 0)
                {
                    throw new NegativeAmountException(amount);
                }

                break;
            case TransactionType.Withdraw:
                if (amount.Value >= 0)
                {
                    throw new PositiveAmountException(amount);
                }

                break;
            default:
                throw new InvalidTransactionTypeException(type);
        }
    }
}