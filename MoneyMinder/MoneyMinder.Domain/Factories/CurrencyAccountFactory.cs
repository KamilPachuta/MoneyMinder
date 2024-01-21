using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Factories.Interfaces;

namespace MoneyMinder.Domain.Factories;

public class CurrencyAccountFactory : ICurrencyAccountFactory
{
    public CurrencyAccount Create(CurrencyAccountName name)
    {
        var id = Guid.NewGuid();
        
        var currencyAccount = new CurrencyAccount(id, name);

        return currencyAccount;
    }
}