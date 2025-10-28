using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Models.Dtos;

public class SavingsTransactionDto
{
    public CurrencyDto Currency { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionTypeDto TransactionType { get; set; }
}