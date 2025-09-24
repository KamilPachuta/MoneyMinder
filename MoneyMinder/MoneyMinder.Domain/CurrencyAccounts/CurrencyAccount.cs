using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts.DomainEvents;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.Primitives;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts;

public class CurrencyAccount : AggregateRoot
{
    public CurrencyAccountName Name { get; private set; }
    
    public Account Account { get; init; }

    public List<Balance> Balances { get; } = new ();
    public List<Income> Incomes { get; } = new ();
    public List<Payment> Payments { get; } = new ();
    public List<Budget> Budgets { get; } = new ();
    
    
    private CurrencyAccount()
    {
    }

    internal CurrencyAccount(Guid id, CurrencyAccountName name, Account account)
        : base(id)
    {
        Name = name;
        Account = account;
        
        RaiseDomainEvent(new CurrencyAccountCreatedDomainEvent(DateTime.UtcNow, this));
    }
    
    
    public void ChangeName(CurrencyAccountName name)
    {
        var oldName = Name;

        Name = name;
        
        RaiseDomainEvent(new CurrencyAccountNameChangedDomainEvent(oldName, name, this));
    }
    
    public void AddIncome(Income income)
    {
        if (Incomes.Any(i => i == income))
        {
            throw new IncomeAlreadyExistException(income);
        }
        
        ProcessTransaction(income);
        
        Incomes.Add(income);
        
        RaiseDomainEvent(new IncomeAddedDomainEvent(income, this));
    }
    
    public void RemoveIncome(Transaction transaction)
    {
        var income = Incomes.FirstOrDefault(i => i == transaction);
        
        if (income is null)
        {
            throw new IncomeNotFoundException(transaction.Id);
        }
        
        RollbackTransaction(income);
        
        Incomes.Remove(income);
        
        RaiseDomainEvent(new IncomeRemovedDomainEvent(income, this));
    }
    
    public void AddPayment(Payment payment)
    {
        if (Payments.Any(p => p == payment))
        {
            throw new PaymentAlreadyExistException(payment);
        }
        
        ProcessTransaction(payment);
        
        Payments.Add(payment);
        
        RaiseDomainEvent(new PaymentAddedDomainEvent(payment, this));
    }
    
    public void RemovePayment(Guid id)
    {
        var payment = Payments.FirstOrDefault(i => i.Id == id);

        if (payment is null)
        {
            throw new PaymentNotFoundException(id);
        }
        
        RollbackTransaction(payment);
        
        Payments.Remove(payment);
        
        RaiseDomainEvent(new PaymentRemovedDomainEvent(payment, this));
    }
    
    public void CreateBudget(Budget budget)
    {
        if(Budgets.Exists(b => b.Exist(budget.Date)))
            throw new BudgetAlreadyExistException();
        
        Budgets.Add(budget);
        
        RaiseDomainEvent(new BudgetCreatedDomainEvent(budget, this));
    }
    
    public void EditLimit(Limit limit)
    {
        var budget = Budgets.FirstOrDefault(b => b.Exist(DateTime.UtcNow));

        if (budget is null)
            throw new BudgetNotFoundException();

        budget.ModifyLimit(limit);
        
        RaiseDomainEvent(new LimitEditedDomainEvent(limit, this));
    }
    
    public void DeleteBudget()
    {
        var budget = Budgets.FirstOrDefault(b => b.Exist(DateTime.UtcNow));

        if (budget is null)
            throw new BudgetNotFoundException();
        
        RaiseDomainEvent(new BudgetDeletedDomainEvent(budget, this));
    }
    
    /*public void ConvertCurrencyTo(Currency from, Currency to, decimal amount, decimal coefficient)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException(amount);
        }

        var income = new Income(new TransactionName("Currency conversion"), DateTime.UtcNow, to, new Amount(amount));

        var convertedAmount = new Amount(-1*(amount / coefficient));

        var payment = new Payment(new TransactionName("Currency Conversion"), DateTime.UtcNow, from, convertedAmount, Category.Other);


        AddIncome(income);
        AddPayment(payment);
        
        RaiseDomainEvent(new CurrencyConvertedToDomainEvent(from, to, amount, coefficient, this));
    }
    
    public void ConvertCurrencyFrom(Currency from, Currency to, decimal amount, decimal coefficient)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException(amount);
        }

        var payment = new Payment(new TransactionName("Currency Conversion"), DateTime.UtcNow, from, new Amount(-1 * amount),
            Category.Entertainment);

        var convertedAmount = new Amount(amount * coefficient);
        
        var income = new Income(new TransactionName("Currency conversion"), DateTime.UtcNow, to, convertedAmount);


        AddIncome(income);
        AddPayment(payment);
        
        RaiseDomainEvent(new CurrencyConvertedFromDomainEvent(from, to, amount, coefficient, this));
    }*/
    
    
    private void ProcessTransaction(Transaction transaction)
    {
        if (BalanceExist(transaction.Currency))
        {
            var balance = GetBalance(transaction.Currency);
            balance.ChangeAmount(transaction.Amount);
        }
        else
        {
            var balance = new Balance(transaction.Currency);
            balance.ChangeAmount(transaction.Amount);
            Balances.Add(balance);
        }
        
        RaiseDomainEvent(new TransactionProcessedDomainEvent(transaction, this));
    }
    
    private void RollbackTransaction(Transaction transaction)
    {
        var balance = GetBalance(transaction.Currency);

        var amount = new Amount(-transaction.Amount.Value);
        
        balance.ChangeAmount(amount);
    }
    
    private Balance GetBalance(DefinedCurrency currency)
    {
        var balance = Balances.FirstOrDefault(b => b.Currency == currency);
        
        if (balance is null)
        {
            throw new BalanceNotFoundException(currency);
        }

        return balance;
    }
    
    private bool BalanceExist(DefinedCurrency currency)
        => Balances.Exists(b => b.Currency == currency);
}