using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class AddMonthlyPaymentRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? Date { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

    public AddMonthlyPaymentRequest(Guid id, string name, DateTime date, Currency currency, decimal amount, Category category)
    {
        Id = id;
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
        Category = category;
    }

    public AddMonthlyPaymentRequest() { }
}
