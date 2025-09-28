using MoneyMinder.Domain.Shared.Exceptions;

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

        if (date.Date > DateTime.UtcNow.Date)
        {
            throw new TransactionDateInFutureException(date);
        }
        
        Date = date;
    }
    
    public static implicit operator DateTime(TransactionDate transactionDate)
        => transactionDate.Date;
    
    public static implicit operator TransactionDate(DateTime date)
        => new(date);
}