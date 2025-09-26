using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.SavingsAccounts;
using MoneyMinder.Domain.SavingsAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.Factories.Interfaces;

public interface ISavingsAccountFactory
{
    SavingsAccount Create(SavingsAccountName name, DefinedCurrency currency, Amount plannedAmount, Account account);
}