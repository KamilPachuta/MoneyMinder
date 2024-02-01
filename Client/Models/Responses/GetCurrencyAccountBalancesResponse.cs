using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetCurrencyAccountBalancesResponse: IResponse
{
    public IEnumerable<BalanceModel> Balances { get; }

    public GetCurrencyAccountBalancesResponse()
    {
        
    }

    public GetCurrencyAccountBalancesResponse(IEnumerable<BalanceModel> balances) 
    {
        Balances = balances;
    }
}