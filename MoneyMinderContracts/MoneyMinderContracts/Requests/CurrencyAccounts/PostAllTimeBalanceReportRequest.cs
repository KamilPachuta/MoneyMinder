using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class PostAllTimeBalanceReportRequest
{
    public IEnumerable<Guid> CurrencyAccountIds { get; set; }
    public IEnumerable<CurrencyDto> Currencies { get; set; }

    public PostAllTimeBalanceReportRequest()
    {
        
    }
    
    public PostAllTimeBalanceReportRequest(IEnumerable<Guid> currencyAccountIds, IEnumerable<CurrencyDto> currencies)
    {
        CurrencyAccountIds = currencyAccountIds;
        Currencies = currencies;
    }
}