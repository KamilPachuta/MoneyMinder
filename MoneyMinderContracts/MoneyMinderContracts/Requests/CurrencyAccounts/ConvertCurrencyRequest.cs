using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class ConvertCurrencyRequest
{
    public Guid CurrencyAccountId { get; set; }
    public decimal Amount { get; set; }
    public decimal Coefficient { get; set; }
    public CurrencyDto From { get; set; }
    public CurrencyDto To { get; set; }

    public ConvertCurrencyRequest()
    {
        
    }
    
    public ConvertCurrencyRequest(Guid currencyAccountId, decimal amount, decimal coefficient, CurrencyDto from, CurrencyDto to)
    {
        CurrencyAccountId = currencyAccountId;
        Amount = amount;
        Coefficient = coefficient;
        From = from;
        To = to;
    }
    
    
}
