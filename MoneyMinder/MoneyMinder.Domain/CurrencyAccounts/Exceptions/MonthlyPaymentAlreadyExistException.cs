using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;


internal sealed class MonthlyPaymentAlreadyExistException : MoneyMinderException
{
    public TransactionName Name { get; set; }
    
    public MonthlyPaymentAlreadyExistException(TransactionName name)
        : base($"Monthly payment: '{name}' already exist.")
    {
        Name = name;
    }
    
}