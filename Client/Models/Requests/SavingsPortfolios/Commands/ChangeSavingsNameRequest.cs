namespace Client.Models.Requests.SavingsPortfolios.Commands;

public class ChangeSavingsNameRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ChangeSavingsNameRequest()
    {
        // Konstruktor bezparametrowy
    }

    public ChangeSavingsNameRequest(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}