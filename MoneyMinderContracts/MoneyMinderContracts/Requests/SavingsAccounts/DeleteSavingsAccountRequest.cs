namespace MoneyMinderContracts.Requests.SavingsAccounts;

public class DeleteSavingsAccountRequest
{
    public Guid SavingsAccountId { get; set; }

    public DeleteSavingsAccountRequest()
    {
    }
    
    public DeleteSavingsAccountRequest(Guid savingsAccountId)
    {
        SavingsAccountId = savingsAccountId;
    }
}
