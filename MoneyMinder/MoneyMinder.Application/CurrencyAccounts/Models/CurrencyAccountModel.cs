namespace MoneyMinder.Application.CurrencyAccounts.Models;

// public record CurrencyAccountModel(
//     Guid Id,
//     string Name, 
//     BudgetModel Budget, 
//     IEnumerable<BalanceModel> Balances, 
//     IEnumerable<IncomeModel> Incomes, 
//     IEnumerable<PaymentModel> Payments, 
//     IEnumerable<MonthlyIncomeModel> MonthlyIncomes, 
//     IEnumerable<MonthlyPaymentModel> MonthlyPayments);

public class CurrencyAccountModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public BudgetModel Budget { get; set; }
    public IEnumerable<BalanceModel> Balances { get; set; }
    public IEnumerable<IncomeModel> Incomes { get; set; }
    public IEnumerable<PaymentModel> Payments { get; set; }
    public IEnumerable<MonthlyIncomeModel> MonthlyIncomes { get; set; }
    public IEnumerable<MonthlyPaymentModel> MonthlyPayments { get; set; }

    

    
    public CurrencyAccountModel()
    {
        
    }

    public CurrencyAccountModel(
        Guid id,
        string name,
        BudgetModel budget,
        IEnumerable<BalanceModel> balances,
        IEnumerable<IncomeModel> incomes,
        IEnumerable<PaymentModel> payments,
        IEnumerable<MonthlyIncomeModel> monthlyIncomes,
        IEnumerable<MonthlyPaymentModel> monthlyPayments)
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
