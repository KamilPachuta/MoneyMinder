namespace MoneyMinder.Domain.Shared.ValueObjects;

public record TransactionDate
{
    public DateTime Date { get; }

    public TransactionDate(DateTime date)
    {
        if (date.Kind != DateTimeKind.Utc)
        {
            date = date.ToUniversalTime();
        }
        
        Date = date;
    }
    
    public static implicit operator DateTime(TransactionDate transactionDate)
        => transactionDate.Date;
    
    public static implicit operator TransactionDate(DateTime date)
        => new(date);
}