using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.SavingsAccounts.Exceptions;

public sealed class SavingsAccountNotFoundException : MoneyMinderException
{
    public SavingsAccountNotFoundException(Guid Id) 
        : base($"Savings account with ID: '{Id}' was not found.")
    {
    }

    public SavingsAccountNotFoundException(string name) 
        : base($"Savings account with name: '{name}' was not found.")
    {
    }
}
