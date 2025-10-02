namespace MoneyMinderContracts.Requests.SavingsAccounts;

public class ChangeSavingsAccountNameRequest
{
    public Guid SavingsAccountId { get; set; }
    public string Name { get; set; } = string.Empty;

    public ChangeSavingsAccountNameRequest()
    {
    }
    
    public ChangeSavingsAccountNameRequest(Guid savingsAccountId, string name)
    {
        SavingsAccountId = savingsAccountId;
        Name = name;
    }
}
