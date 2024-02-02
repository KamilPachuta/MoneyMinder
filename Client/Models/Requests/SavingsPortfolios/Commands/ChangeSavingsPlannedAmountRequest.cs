namespace Client.Models.Requests.SavingsPortfolios.Commands;

public class ChangeSavingsPlannedAmountRequest
{
    public Guid Id { get; set; }
    public decimal PlannedAmount { get; set; }

    public ChangeSavingsPlannedAmountRequest()
    {
        // Konstruktor bezparametrowy
    }

    public ChangeSavingsPlannedAmountRequest(Guid id, decimal plannedAmount)
    {
        Id = id;
        PlannedAmount = plannedAmount;
    }
}