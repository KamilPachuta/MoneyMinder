namespace MoneyMinder.Infrastructure.EF.ReadModels.Account;

public class NotificationReadModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    
    
    public Guid AccountId { get; set; }

    public NotificationReadModel()
    {
        
    }
    
    public NotificationReadModel(Guid id, string title, string description, DateTime date)
    {
        Id = id;
        Title = title;
        Description = description;
        Date = date;
    }
}