using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.DomainEvents;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class CurrencyAccount : AggregateRoot
{
    public CurrencyAccountName Name { get; private set; }
    
    public Budget Budget { get; private set; }
    
    public IEnumerable<Balance> Balances => _balances;
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
    
    
    
    private bool BalanceExist(Currency currency)
        => _balances.Exists(b => b.Currency == currency);
    
    private Balance GetBalance(Currency currency)
    {
        var balance = _balances.FirstOrDefault(b => b.Currency == currency);
        
        if (balance is null)
        {
            throw new BalanceNotFoundException(currency);
        }

        return balance;
    }
    
    private void ProcessTransaction(Transaction transaction)
    {
        Balance balance;
        
        if (BalanceExist(transaction.Currency))
        {
            balance = GetBalance(transaction.Currency);
            balance.ChangeAmount(transaction.Amount);
        }
        else
        {
            balance = new Balance(transaction.Currency);
            balance.ChangeAmount(transaction.Amount);
            _balances.Add(balance);
        }
        
        RaiseDomainEvent(new TransactionProcessedDomainEvent(transaction, this));
    }

    private void RollbackTransaction(Transaction transaction)
    {
        var balance = GetBalance(transaction.Currency);

        var amount = new Amount(-transaction.Amount.Value);
        
        balance.ChangeAmount(amount);
    }
    
    
    
    public void ChangeName(CurrencyAccountName name)
    {
        var oldName = Name;

        Name = name;
        
        RaiseDomainEvent(new CurrencyAccountNameChangedDomainEvent(oldName, name, this));
    }
    
    public void AddIncome(Income income)
    {
        if (income.Date.Day > DateTime.Today.Day)
        {
            throw new TransactionDateLaterThanExpectedException(income);
        }
        
        ProcessTransaction(income);
        
        _incomes.Add(income);
        
        RaiseDomainEvent(new IncomeAddedDomainEvent(income, this));
    }
    
    public void AddPayment(Payment payment)
    {
        if (payment.Date.Day > DateTime.Today.Day)
        {
            throw new TransactionDateLaterThanExpectedException(payment);
        }
        ProcessTransaction(payment);
        
        _payments.Add(payment);
        
        RaiseDomainEvent(new PaymentAddedDomainEvent(payment, this));
    }

    public void RemoveIncome(Transaction transaction)
    {
        var income = _incomes.FirstOrDefault(i => i == transaction);

        if (income is null)
        {
            throw new IncomeNotFoundException(transaction);
        }
        
        RollbackTransaction(income);
        
        _incomes.Remove(income);
        
        RaiseDomainEvent(new IncomeRemovedDomainEvent(income, this));
    }
    
    public void RemovePayment(Transaction transaction)
    {
        var payment = _payments.FirstOrDefault(i => i == transaction);

        if (payment is null)
        {
            throw new PaymentNotFoundException(transaction);
        }
        
        RollbackTransaction(payment);
        
        _payments.Remove(payment);
        
        RaiseDomainEvent(new PaymentRemovedDomainEvent(payment, this));
    }
    
    public void AddMonthlyIncome(MonthlyIncome monthlyIncome)
    {
        
    }

    public void EditMonthlyIncome(MonthlyIncome name, Amount amount)
    {
        
    }
    
    public void RemoveMonthlyIncome(MonthlyIncome monthlyIncome)
    {
        
    }
        
    public void AddMonthlyPayment(MonthlyPayment monthlyPayment)
    {
        
    }

    public void EditMonthlyPayment(MonthlyTransactionName name, Amount amount)
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