namespace Client.Models.Requests.CurrencyAccount.Commands;

public class RemoveMonthlyIncomeRequest
{
    public Guid Id { get; set; }
    public string MonthlyIncomeName { get; set; }
 
    public RemoveMonthlyIncomeRequest()
    {
        
    }
    
    public RemoveMonthlyIncomeRequest(Guid id, string monthlyIncomeName)
    {
        Id = id;
        MonthlyIncomeName = monthlyIncomeName;
    }
    
}
