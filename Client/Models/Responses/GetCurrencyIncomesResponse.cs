using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetCurrencyIncomesResponse : IResponse
{
    public IEnumerable<TransactionModel> Transactionsc { get; set; }

    public GetCurrencyIncomesResponse()
    {
        
    }
    
    public GetCurrencyIncomesResponse(IEnumerable<TransactionModel> transactionsc)
    {
        Transactionsc = transactionsc;
    }
    
}