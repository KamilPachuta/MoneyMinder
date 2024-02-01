namespace Client.Models.ReadModels;

public class CurrencyAccountNameModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public CurrencyAccountNameModel()
    {
        
    }
    
    public CurrencyAccountNameModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    
}
