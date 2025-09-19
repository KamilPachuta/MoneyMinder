namespace MoneyMinder.Domain.Shared.ValueObjects;

public record TransactionAmount
{
    public decimal Amount { get; }

    public TransactionAmount(decimal amount)
    {
        Amount = amount;
    }
    
        
    public static implicit operator decimal(TransactionAmount amount)
        => amount.Amount; 

    public static implicit operator TransactionAmount(decimal amount)
        => new(amount);
}