namespace Client.Models.Requests.CurrencyAccount.Commands;

public class ChangeBudgetNameRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ChangeBudgetNameRequest()
    {
        // Konstruktor bezparametrowy
    }

    public ChangeBudgetNameRequest(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}