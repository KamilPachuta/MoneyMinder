namespace MoneyMinderContracts.Requests.SavingsAccounts;

public class ChangeSavingsAccountPlannedAmountRequest
{
    public Guid SavingsAccountId { get; set; }
    public decimal PlannedAmount { get; set; }

    public ChangeSavingsAccountPlannedAmountRequest()
    {
    }
    
    public ChangeSavingsAccountPlannedAmountRequest(Guid savingsAccountId, decimal plannedAmount)
    {
        SavingsAccountId = savingsAccountId;
        PlannedAmount = plannedAmount;
    }
}
