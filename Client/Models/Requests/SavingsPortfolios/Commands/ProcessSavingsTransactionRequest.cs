using Client.Models.Enums;

namespace Client.Models.Requests.SavingsPortfolios.Commands;

public class ProcessSavingsTransactionRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? Date { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }

    public ProcessSavingsTransactionRequest()
    {
        
    }
    
    public ProcessSavingsTransactionRequest(Guid id, string name, DateTime date, decimal amount, TransactionType type)
    {
        Id = id;
        Name = name;
        Date = date;
        Amount = amount;
        Type = type;
    }

}