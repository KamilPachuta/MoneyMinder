namespace Client.Models.Requests.CurrencyAccount.Commands;

public record RemoveMonthlyPaymentRequest
{
    public Guid Id { get; set; }
    public string MonthlyPaymentName { get; set; }

    public RemoveMonthlyPaymentRequest()
    {
        
    }
    
    public RemoveMonthlyPaymentRequest(Guid id, string monthlyPaymentName)
    {
        Id = id;
        MonthlyPaymentName = monthlyPaymentName;
    }
}
