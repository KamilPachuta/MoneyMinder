using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.DomainEvents;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class CurrencyAccount : AggregateRoot
{
    public CurrencyAccountName Name { get; private set; }
    
    public Budget Budget { get; private set; }
    
    // public IEnumerable<Balance> Balances => _balances;
    // public IEnumerable<Income> Incomes => _incomes;
    // public IEnumerable<Payment> Payments => _payments;
    // public IEnumerable<MonthlyIncome> MonthlyIncomes => _monthlyIncomes;
    // public IEnumerable<MonthlyPayment> MonthlyPayments => _monthlyPayments;

    
    
    private readonly List<Balance> _balances = new();
    private readonly List<Income> _incomes = new();
    private readonly List<Payment> _payments = new();
    private readonly List<MonthlyIncome> _monthlyIncomes = new();
    private readonly List<MonthlyPayment> _monthlyPayments = new();

    private CurrencyAccount() 
    {
    }
    
    public CurrencyAccount(Guid id, CurrencyAccountName name) 
        : base(id)
    {
        Name = name;
    }

    public void ChangeName(CurrencyAccountName name)
    {
        
    }
    
    public void AddIncome(Income income)
    {
        if (income.Date.Day > DateTime.Today.Day)
        {
            throw new TransactionDateLaterThanExpectedException(income);
        }
        
        _incomes.Add(income);
        
        RaiseDomainEvent(new IncomeAddedDomainEvent(income, this));
    }
    
    public void RemoveIncome(TransactionName name)
    {
        var income = _incomes.FirstOrDefault(i => i.Name == name);

        if (income is null)
        {
            throw new IncomeNotFoundException(name);
        }

        var balance = GetBalance(income.Currency);
        
        if (income.Amount > balance.Amount)
        {
            throw new InsufficientFundsToRemoveIncomeException(income);
        }
        
        _incomes.Remove(income);
    }
    
    public void AddPayment(Payment payment)
    {
        if (payment.Date.Day > DateTime.Today.Day)
        {
            throw new TransactionDateLaterThanExpectedException(payment);
        }
        
        _payments.Add(payment);
        
        RaiseDomainEvent(new PaymentAddedDomainEvent(payment, this));
    }

    private Balance GetBalance(Currency currency)
    {
        var balance = _balances.FirstOrDefault(b => b.Currency == currency);
        
        if (balance is null)
        {
            throw new BalanceNotFoundException(currency);
        }

        return balance;
    }
    
    public void RemovePayment(TransactionName name)
    {
        var payment = _payments.FirstOrDefault(i => i.Name == name);

        if (payment is null)
        {
            throw new PaymentNotFoundException(name);
        }

        var balance = GetBalance(payment.Currency);
        
        if (payment.Amount > balance.Amount)
        {
            throw new InsufficientFundsToRemovePaymentException(payment);
        }
        
        _payments.Remove(payment);
    }
    
    public void AddMonthlyIncome(MonthlyIncome monthlyIncome)
    {
        
    }

    public void EditMonthlyIncome(MonthlyTransactionName name, decimal amount)
    {
        
    }
    
    public void RemoveMonthlyIncome(MonthlyIncome monthlyIncome)
    {
        
    }
        
    public void AddMonthlyPayment(MonthlyPayment monthlyPayment)
    {
        
    }

    public void EditMonthlyPayment(MonthlyTransactionName name, decimal amount)
    {
        
    }

    public void RemoveMonthlyPayment(MonthlyPayment monthlyPayment)
    {
        
    }


    public void AcceptMonthlyTransaction(MonthlyTransaction monthlyTransaction)
    {
        
    }

    public void CreateBudget(Budget budget)
    {
        //Czy budget jest na ten miesiac? czy poprzedni jest na ten? jesli tak to exception bo musi byc na poprzdedni
    }

    public void ConvertCurrency()
    {
        
    }
    
    //add new balance
    
    // currency conversion
    
   
    
    //add monthly income (new) (delete, edit - name, amount)
    
 
    
    //add monthly payment (new) (delete, edit)
    
    //accept monthly transaction (current month transaction into next month transaction and added transaction)
    
    //add budget
    // edit budget name
    // edit expenses?
    // co z powiadomieniami
    
    
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