namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class ChangeCurrencyAccountNameRequest
{
    public Guid CurrencyAccountId { get; set; }
    public string Name { get; set; } = string.Empty;

    public ChangeCurrencyAccountNameRequest()
    {
    }
    
    public ChangeCurrencyAccountNameRequest(Guid currencyAccountId, string name)
    {
        CurrencyAccountId = currencyAccountId;
        Name = name;
    }
}
