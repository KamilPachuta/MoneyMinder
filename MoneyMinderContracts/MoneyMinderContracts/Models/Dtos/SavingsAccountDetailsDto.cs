using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Models.Dtos;

public class SavingsAccountDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public CurrencyDto Currency { get; set; }
    public decimal CurrentAmount { get; set; }
    public decimal PlannedAmount { get; set; }
}