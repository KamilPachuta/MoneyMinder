using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetCurrencyPaymentsResponse : IResponse
{
    public IEnumerable<TransactionModel> Transactions { get; set; }

    public GetCurrencyPaymentsResponse()
    {
        
    }
    
    public GetCurrencyPaymentsResponse(IEnumerable<TransactionModel> transactions)
    {
        Transactions = transactions;
    }
    
}