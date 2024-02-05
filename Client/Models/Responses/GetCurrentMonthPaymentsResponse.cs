using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetCurrentMonthPaymentsResponse : IResponse
{
    public IEnumerable<PaymentModel> Payments { get; set; }

    public GetCurrentMonthPaymentsResponse()
    {
        
    }
    
    public GetCurrentMonthPaymentsResponse(IEnumerable<PaymentModel> payments)
    {
        Payments = payments;
    }
}