using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.Accounts.Entities;

public class Notification : Entity
{
    public NotificationTitle Title { get; }
    public NotificationDescription Description { get; }
    public DateTime Date { get; set; }
    

    private Notification()
    {
    }
    
    public Notification(NotificationTitle title, NotificationDescription description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
    }
    
}