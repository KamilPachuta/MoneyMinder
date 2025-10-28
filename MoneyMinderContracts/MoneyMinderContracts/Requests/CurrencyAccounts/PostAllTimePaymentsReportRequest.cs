using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class PostAllTimePaymentsReportRequest
{
    public IEnumerable<Guid> CurrencyAccountIds { get; set; }
    public IEnumerable<CurrencyDto> Currencies { get; set; }

    public PostAllTimePaymentsReportRequest()
    {
    }
    
    public PostAllTimePaymentsReportRequest(IEnumerable<CurrencyDto> currencies, IEnumerable<Guid> currencyAccountIds)
    {
        Currencies = currencies;
        CurrencyAccountIds = currencyAccountIds;
    }
    
}