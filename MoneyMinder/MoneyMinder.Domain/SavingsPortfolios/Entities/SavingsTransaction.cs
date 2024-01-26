using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.SavingsPortfolios.Enums;
using MoneyMinder.Domain.SavingsPortfolios.Exceptions;
using NegativeAmountException = MoneyMinder.Domain.SavingsPortfolios.Exceptions.NegativeAmountException;

namespace MoneyMinder.Domain.SavingsPortfolios.Entities;

public class SavingsTransaction : Transaction
{
    public TransactionType Type { get; set; }

    public SavingsTransaction(TransactionName name, DateTime date, Currency currency, Amount amount, TransactionType type) : base(name, date, currency, amount)
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