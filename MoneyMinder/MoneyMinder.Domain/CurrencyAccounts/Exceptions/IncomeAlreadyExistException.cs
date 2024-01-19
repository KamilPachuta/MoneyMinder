using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class IncomeAlreadyExistException : MoneyMinderException
{
    public Income Income { get; set; }
    
    public IncomeAlreadyExistException(Income income)
        : base($"Income: '{income}' already exist.")
    {
        Income = income;
    }
    
}




