using System.Diagnostics;
using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetCurrencyAccountTransactionsResponse : IResponse
{
    public IEnumerable<TransactionModel> Transactions { get; set; }

    public GetCurrencyAccountTransactionsResponse()
    {
        
    }
    
    public GetCurrencyAccountTransactionsResponse(IEnumerable<TransactionModel> transactions)
    {
        Transactions = transactions;
    }
}