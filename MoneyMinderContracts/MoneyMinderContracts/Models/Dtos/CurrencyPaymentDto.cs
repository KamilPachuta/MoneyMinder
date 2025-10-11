using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Models.Dtos;

public class CurrencyPaymentDto
{
    public DateTime Date { get; set; }
    public CurrencyDto Currency { get; set; }
    public decimal Amount { get; set; }
    public CategoryDto Category { get; set; }
}