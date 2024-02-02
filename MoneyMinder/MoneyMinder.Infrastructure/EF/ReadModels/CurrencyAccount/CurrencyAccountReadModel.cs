namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

public class CurrencyAccountReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public BudgetReadModel Budget { get; set; }
    public IEnumerable<BalanceReadModel> Balances { get; set; }
    public IEnumerable<IncomeReadModel> Incomes { get; set; }
    public IEnumerable<PaymentReadModel> Payments { get; set; }
    public IEnumerable<MonthlyIncomeReadModel> MonthlyIncomes { get; set; }
    public IEnumerable<MonthlyPaymentReadModel> MonthlyPayments { get; set; }

    public Guid AccountId { get; set; }    

    
    public CurrencyAccountReadModel()
    {
        
    }

    public CurrencyAccountReadModel(
        Guid id,
        string name,
        BudgetReadModel budget,
        IEnumerable<BalanceReadModel> balances,
        IEnumerable<IncomeReadModel> incomes,
        IEnumerable<PaymentReadModel> payments,
        IEnumerable<MonthlyIncomeReadModel> monthlyIncomes,
        IEnumerable<MonthlyPaymentReadModel> monthlyPayments)
    {
        Id = id;
        Name = name;
        Budget = budget;
        Balances = balances;
        Incomes = incomes;
        Payments = payments;
        MonthlyIncomes = monthlyIncomes;
        MonthlyPayments = monthlyPayments;
    }
}
