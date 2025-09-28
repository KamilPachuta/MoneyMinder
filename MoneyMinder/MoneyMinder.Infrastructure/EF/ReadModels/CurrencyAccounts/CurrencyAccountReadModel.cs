namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccounts;

public class CurrencyAccountReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<BalanceReadModel> Balances { get; set; }
    public IEnumerable<IncomeReadModel> Incomes { get; set; }
    public IEnumerable<PaymentReadModel> Payments { get; set; }
    public IEnumerable<BudgetReadModel> Budgets { get; set; }

    public Guid AccountId { get; set; }    

    
    public CurrencyAccountReadModel()
    {
    }

    public CurrencyAccountReadModel(
        Guid id,
        string name,
        IEnumerable<BalanceReadModel> balances,
        IEnumerable<IncomeReadModel> incomes,
        IEnumerable<PaymentReadModel> payments,
        IEnumerable<BudgetReadModel> budgets)
    {
        Id = id;
        Name = name;
        Balances = balances;
        Incomes = incomes;
        Payments = payments;
        Budgets = budgets;
    }
}