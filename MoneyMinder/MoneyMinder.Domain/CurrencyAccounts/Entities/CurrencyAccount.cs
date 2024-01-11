using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class CurrencyAccount : AggregateRoot
{
    public CurrencyAccountName Name { get; private set; }
    
    public IEnumerable<Balance> Balances => _balances;
    public IEnumerable<Income> Incomes => _incomes;
    public IEnumerable<Payment> Payments => _payments;

    private readonly List<Balance> _balances = new();
    private readonly List<Income> _incomes = new();
    private readonly List<Payment> _payments = new();

    private CurrencyAccount() 
    {
    }
    
    public CurrencyAccount(Guid id, CurrencyAccountName name) : base(id)
    {
        Name = name;
    }
    
    //add new balance
    
    
}