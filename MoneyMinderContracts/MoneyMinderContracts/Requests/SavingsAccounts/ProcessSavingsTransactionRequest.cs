using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Requests.SavingsAccounts;

public class ProcessSavingsTransactionRequest
{
    public Guid SavingsAccountId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public CurrencyDto CurrencyDto { get; set; }
    public decimal Amount { get; set; }
    public TransactionTypeDto TransactionTypeDto { get; set; }

    public ProcessSavingsTransactionRequest()
    {
    }
    
    public ProcessSavingsTransactionRequest(
        Guid savingsAccountId, 
        string name, 
        DateTime date, 
        CurrencyDto currencyDto, 
        decimal amount, 
        TransactionTypeDto transactionTypeDto)
    {
        SavingsAccountId = savingsAccountId;
        Name = name;
        Date = date;
        CurrencyDto = currencyDto;
        Amount = amount;
        TransactionTypeDto = transactionTypeDto;
    }
}
