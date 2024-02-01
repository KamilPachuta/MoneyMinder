namespace Client.Models.Requests.CurrencyAccount.Commands;

public class CreateCurrencyAccountRequest
{
    public string Name { get; set; }

    public CreateCurrencyAccountRequest()
    {
    }

    public CreateCurrencyAccountRequest(string name)
    {
        Name = name;
    }
}
