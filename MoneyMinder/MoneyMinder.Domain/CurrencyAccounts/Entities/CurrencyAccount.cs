using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class CurrencyAccount : AggregateRoot
{
    public CurrencyAccountName Name { get; private set; }
    
    public Budget Budget { get; private set; }
    
    public IEnumerable<Balance> Balances => _balances;
    public IEnumerable<Income> Incomes => _incomes;
    public IEnumerable<Payment> Payments => _payments;

    private readonly List<Balance> _balances = new();
    private readonly List<Income> _incomes = new();
    private readonly List<Payment> _payments = new();

    private CurrencyAccount() 
    {
    }
    
    public CurrencyAccount(Guid id, CurrencyAccountName name) 
        : base(id)
    {
        Name = name;
    }
    
    //add new balance
    
    // currency conversion
    
    //add income (delete i edit name)
    
    //add payment (delete i edit name)
    
    //add budget
    
    
    /// <summary>
    /// Checks if the budget month matches the current month.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if the budget month matches the current month; otherwise, <c>false</c>.
    /// </returns>
    private bool BudgetMonthCheck()
    {
        if (Budget.Date.Date.Month == DateTime.Today.Month)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}