namespace MoneyMinderContracts.Requests.SavingsAccounts;

public class PostAllTimeSavingsReportRequest
{
     public IEnumerable<Guid> SavingsAccountIds { get; set; }

     public PostAllTimeSavingsReportRequest()
     {
          
     }
     
     public PostAllTimeSavingsReportRequest(IEnumerable<Guid> savingsAccountIds)
     {
          SavingsAccountIds = savingsAccountIds;
     }
}