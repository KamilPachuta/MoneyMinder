using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.SavingsAccounts;
using MoneyMinder.Domain.SavingsAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.Factories;

public class SavingsAccountFactory : ISavingsAccountFactory
{
    public SavingsAccount Create(SavingsAccountName name, DefinedCurrency currency, Amount plannedAmount, Account account)
        => new(Guid.NewGuid(),name, currency, plannedAmount, account);
}