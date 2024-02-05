using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class CreateBudgetRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal ExpectedIncome { get; set; }
    public IEnumerable<KeyValuePair<Category, decimal>> Expenses { get; set; }
    public DateTime Date { get; set; }
    public Currency Currency { get; set; }

    public CreateBudgetRequest()
    {
        // Konstruktor bezparametrowy
    }

    public CreateBudgetRequest(Guid id, string name, decimal expectedIncome, IEnumerable<KeyValuePair<Category, decimal>> expenses, DateTime date, Currency currency)
    {
        Id = id;
        Name = name;
        ExpectedIncome = expectedIncome;
        Expenses = expenses;
        Date = date;
        Currency = currency;
    }
}