namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class DeleteCurrencyAccountRequest
{
    public Guid CurrencyAccountId { get; set; }

    public DeleteCurrencyAccountRequest()
    {
    }
    
    public DeleteCurrencyAccountRequest(Guid currencyAccountId)
    {
        CurrencyAccountId = currencyAccountId;
    }
}
