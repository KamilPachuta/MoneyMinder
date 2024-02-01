using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetMonthlyTransactionsResponse : IResponse
{
    public IEnumerable<TransactionModel> Transactions { get; set; }

    public GetMonthlyTransactionsResponse()
    {
        
    }
    
    public GetMonthlyTransactionsResponse(IEnumerable<TransactionModel> transactions)
    {
        Transactions = transactions;
    }

}