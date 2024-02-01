namespace MoneyMinder.API.Requests.SavingsPortfolios;

public record ChangeSavingsPlannedAmountRequest(Guid Id, decimal PlannedAmount);