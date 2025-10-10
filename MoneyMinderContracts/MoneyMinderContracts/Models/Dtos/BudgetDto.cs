using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Models.Dtos;

public class BudgetDto
{
    public CurrencyDto Currency { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<LimitDto> Limits { get; set; }
}