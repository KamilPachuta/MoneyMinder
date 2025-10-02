namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class CreateCurrencyAccountRequest
{
    public string Name { get; set; } = string.Empty;

    public CreateCurrencyAccountRequest()
    {
    }
    
    public CreateCurrencyAccountRequest(string name)
    {
        Name = name;
    }
}
