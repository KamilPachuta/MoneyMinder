using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.Factories.Interfaces;

public interface ICurrencyAccountFactory
{
    CurrencyAccount Create(CurrencyAccountName name);
}