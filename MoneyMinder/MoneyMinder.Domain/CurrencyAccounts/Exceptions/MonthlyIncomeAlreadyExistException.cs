using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class MonthlyIncomeAlreadyExistException : MoneyMinderException
{
    public TransactionName Name { get; set; }
    
    public MonthlyIncomeAlreadyExistException(TransactionName name)
        : base($"Monthly income: '{name}' already exist.")
    {
        Name = name;
    }
    
}