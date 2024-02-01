namespace Client.Models.Requests.CurrencyAccount.Commands;

public class ChangeCurrencyAccountNameRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ChangeCurrencyAccountNameRequest()
    {
    }

    public ChangeCurrencyAccountNameRequest(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}