using MoneyMinderContracts.WriteModels;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class EditLimitRequest
{
    public Guid CurrencyAccountId { get; set; }
    public LimitWriteModelDto Limit { get; set; }

    public EditLimitRequest()
    {
    }
    
    public EditLimitRequest(Guid currencyAccountId, LimitWriteModelDto limit)
    {
        CurrencyAccountId = currencyAccountId;
        Limit = limit;
    }
}
