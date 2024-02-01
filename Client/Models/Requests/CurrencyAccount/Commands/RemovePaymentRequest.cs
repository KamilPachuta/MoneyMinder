namespace Client.Models.Requests.CurrencyAccount.Commands;

public record RemovePaymentRequest
{
    public Guid CurrencyAccountId { get; set; }
    public Guid PaymentId { get; set; }

    public RemovePaymentRequest()
    {
        
    }
    
    public RemovePaymentRequest(Guid currencyAccountId, Guid paymentId)
    {
        CurrencyAccountId = currencyAccountId;
        PaymentId = paymentId;
    }
}