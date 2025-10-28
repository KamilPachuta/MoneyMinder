using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class PostPaymentsReportRequest
{
    public IEnumerable<Guid> CurrencyAccountIds { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public IEnumerable<CurrencyDto> Currencies { get; set; }

    public PostPaymentsReportRequest()
    {
    }
    
    public PostPaymentsReportRequest(IEnumerable<Guid> currencyAccountIds, DateTime from, DateTime to, IEnumerable<CurrencyDto> currencies)
    {
        CurrencyAccountIds = currencyAccountIds;
        From = from;
        To = to;
        Currencies = currencies;
    }
}