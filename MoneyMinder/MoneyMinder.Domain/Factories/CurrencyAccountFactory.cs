using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Factories.Interfaces;

namespace MoneyMinder.Domain.Factories;

public class CurrencyAccountFactory : ICurrencyAccountFactory
{
    public CurrencyAccount Create(CurrencyAccountName name, Account account)
        => new(Guid.NewGuid(), name, account);


}