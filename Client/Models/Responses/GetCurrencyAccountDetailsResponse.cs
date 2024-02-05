using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetCurrencyAccountDetailsResponse : IResponse
{
    public CurrencyAccountModel CurrencyAccount { get; set; }

    public GetCurrencyAccountDetailsResponse()
    {
        
    }
    
    public GetCurrencyAccountDetailsResponse(CurrencyAccountModel currencyAccount)
    {
        CurrencyAccount = currencyAccount;
    }

}