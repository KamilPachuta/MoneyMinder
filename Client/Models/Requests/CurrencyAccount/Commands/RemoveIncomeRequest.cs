namespace Client.Models.Requests.CurrencyAccount.Commands;

public class RemoveIncomeRequest
{
    public Guid CurrencyAccountId { get; set; }
    public Guid IncomeId { get; set; }

    public RemoveIncomeRequest()
    {
        
    }
    
    public RemoveIncomeRequest(Guid currencyAccountId, Guid incomeId)
    {
        CurrencyAccountId = currencyAccountId;
        IncomeId = incomeId;
    }
}
    
