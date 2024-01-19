using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InsufficientFundsToRemoveIncomeException : MoneyMinderException
{
    public Income Income { get; set; }
    
    public InsufficientFundsToRemoveIncomeException(Income income)
        : base("Insufficient funds to remove the income.")
    {
        Income = income;
    }
}