using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Models.Dtos;

public class BalanceDto
{
    public CurrencyDto Currency { get; set; }
    public decimal Amount { get; set; }
}