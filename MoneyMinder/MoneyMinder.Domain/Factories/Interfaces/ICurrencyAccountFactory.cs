using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.Factories.Interfaces;

public interface ICurrencyAccountFactory
{
    CurrencyAccount Create(CurrencyAccountName name, Account account);
}