using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Infrastructure.Responses;

public class GetCurrencyAccountNamesResponse 
{
    public IEnumerable<CurrencyAccountNameModel> CurrencyAccountNames { get; }
}