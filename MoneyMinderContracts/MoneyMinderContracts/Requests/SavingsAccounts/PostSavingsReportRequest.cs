namespace MoneyMinderContracts.Requests.SavingsAccounts;

public class PostSavingsReportRequest
{
    public IEnumerable<Guid> SavingsAccountIds { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public PostSavingsReportRequest()
    {
        
    }
    
    public PostSavingsReportRequest(IEnumerable<Guid> savingsAccountIds, DateTime from, DateTime to)
    {
        SavingsAccountIds = savingsAccountIds;
        From = from;
        To = to;
    }
}