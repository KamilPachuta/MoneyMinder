using MoneyMinderContracts.Models.Dtos;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class EditLimitRequest
{
    public Guid CurrencyAccountId { get; set; }
    public LimitDto Limit { get; set; }

    public EditLimitRequest()
    {
    }
    
    public EditLimitRequest(Guid currencyAccountId, LimitDto limit)
    {
        CurrencyAccountId = currencyAccountId;
        Limit = limit;
    }
}
