using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetCurrencyAccountNamesResponse : IResponse
{
    public IEnumerable<CurrencyAccountNameModel> CurrencyAccountNames { get; }

    public GetCurrencyAccountNamesResponse()
    {
        
    }
    
    public GetCurrencyAccountNamesResponse(IEnumerable<CurrencyAccountNameModel> currencyAccountNames)
    {
        CurrencyAccountNames = currencyAccountNames;
    }
}