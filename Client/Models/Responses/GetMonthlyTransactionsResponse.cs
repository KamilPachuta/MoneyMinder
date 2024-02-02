using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetMonthlyTransactionsResponse : IResponse
{
    public IEnumerable<MonthlyTransactionModel> Transactions { get; set; }

    public GetMonthlyTransactionsResponse()
    {
        
    }
    
    public GetMonthlyTransactionsResponse(IEnumerable<MonthlyTransactionModel> transactions)
    {
        Transactions = transactions;
    }

}