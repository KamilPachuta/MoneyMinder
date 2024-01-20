using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Savings.Enums;
using MoneyMinder.Domain.Savings.Exceptons;
using NegativeAmountException = MoneyMinder.Domain.Savings.Exceptons.NegativeAmountException;

namespace MoneyMinder.Domain.Savings.Entities;

public class SavingsTransaction : Transaction
{
    public TransactionType Type { get; set; }

    public SavingsTransaction(Guid id, TransactionName name, DateTime date, Currency currency, Amount amount, TransactionType type) : base(id, name, date, currency, amount)
    {
        CheckAmount(type, amount);
        Type = type;
    }

    protected void CheckAmount(TransactionType type, Amount amount)
    {
        switch (type)
        {
            case TransactionType.Deposit:
                if (amount.Value <= 0)
                {
                    throw new NegativeAmountException(amount);
                }
                break;
            case TransactionType.Withdrawal:
                if (amount.Value >= 0)
                {
                    throw new PositiveAmountException(amount);
                }
                break;
            default:
                throw new TransactionTypeException(type);
        }

    }

}