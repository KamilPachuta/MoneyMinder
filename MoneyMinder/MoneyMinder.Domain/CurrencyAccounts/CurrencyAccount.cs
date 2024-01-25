using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.DomainEvents;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts;

public class CurrencyAccount : AggregateRoot
{
    //VO
    public CurrencyAccountName Name { get; private set; }
    
    
    public Account Account { get; set; }
    
    //Entity
    public Budget? Budget { get; private set; }
    
    // public IEnumerable<Balance> Balances => _balances;
    // // public IEnumerable<Income> Incomes => _incomes;
    // // public IEnumerable<Payment> Payments => _payments;
    // // public IEnumerable<MonthlyIncome> MonthlyIncomes => _monthlyIncomes;
    // // public IEnumerable<MonthlyPayment> MonthlyPayments => _monthlyPayments;
    //
    //
    // //Collections
    // private readonly List<Balance> Balances = new();
    // private readonly List<Income> Incomes = new();
    // private readonly List<Payment> Payments = new();
    // private readonly List<MonthlyIncome> MonthlyIncomes = new();
    // private readonly List<MonthlyPayment> MonthlyPayments = new();

    public List<Balance> Balances { get; } = new ();
    public List<Income> Incomes { get; } = new ();
    public List<Payment> Payments { get; } = new ();
    public List<MonthlyIncome> MonthlyIncomes { get; } = new ();
    public List<MonthlyPayment> MonthlyPayments { get; } = new ();

    

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
    
    
    //// <summary>
    /// Checks if a balance exists for a given currency.
    /// </summary>
    /// <param name="currency">The currency to check for a balance.</param>
    /// <returns>True if a balance exists for the specified currency, otherwise false.</returns>
    private bool BalanceExist(Currency currency)
        => Balances.Exists(b => b.Currency == currency);

    /// <summary>
    /// Checks if a monthly income entry exists with a given name.
    /// </summary>
    /// <param name="name">The name of the monthly income to check.</param>
    /// <returns>True if a monthly income with the specified name exists, otherwise false.</returns>
    private bool MonthlyIncomeExist(TransactionName name) 
        => MonthlyIncomes.Any(mi => mi.Name == name);
    
    /// <summary>
    /// Checks if a monthly payment entry exists with a given name.
    /// </summary>
    /// <param name="name">The name of the monthly payment to check.</param>
    /// <returns>True if a monthly payment with the specified name exists, otherwise false.</returns>
    private bool MonthlyPaymentExist(TransactionName name)
        => MonthlyPayments.Any(mp => mp.Name == name);

    // /// <summary>
    // /// Checks if the budget is for the current month.
    // /// </summary>
    // /// <param name="month">The month associated with the budget to check.</param>
    // /// <returns>True if the budget is for the current month, otherwise false.</returns>
    // private bool BudgetMonthCheck(Month month)
    //     => month.Date.Month == DateTime.Today.Month;


    // private bool BudgetMonthCheck(BudgetDate month)
    // {
    //     
    //     
    //     
    // }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="currency"></param>
    /// <returns></returns>
    /// <exception cref="BalanceNotFoundException"></exception>
    private Balance GetBalance(Currency currency)
    {
        var balance = Balances.FirstOrDefault(b => b.Currency == currency);
        
        if (balance is null)
        {
            throw new BalanceNotFoundException(currency);
        }

        return balance;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="MonthlyIncomeNotFoundException"></exception>
    private MonthlyIncome GetMonthlyIncome(TransactionName name)
    {
        var monthlyIncome = MonthlyIncomes.FirstOrDefault(mi => mi.Name == name);

        if (monthlyIncome is null)
        {
            throw new MonthlyIncomeNotFoundException(name);
        }

        return monthlyIncome;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="MonthlyPaymentNotFoundException"></exception>
    private MonthlyPayment GetMonthlyPayment(TransactionName name)
    {
        var monthlyPayment = MonthlyPayments.FirstOrDefault(mp => mp.Name == name);

        if (monthlyPayment is null)
        {
            throw new MonthlyPaymentNotFoundException(name);
        }

        return monthlyPayment;
    }
    
    /// <summary>
    /// Processes a financial transaction by updating or creating a balance for the associated currency.
    /// </summary>
    /// <param name="transaction">The transaction to be processed.</param>
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

    /// <summary>
    /// Reverses the effects of a transaction on the account balance.
    /// </summary>
    /// <param name="transaction">The transaction to rollback.</param>
    private void RollbackTransaction(Transaction transaction)
    {
        var balance = GetBalance(transaction.Currency);

        var amount = new Amount(-transaction.Amount.Value);
        
        balance.ChangeAmount(amount);
    }
    
    
    
    /// <summary>
    /// Changes the name of the currency account.
    /// </summary>
    /// <param name="name">The new name for the account.</param>
    public void ChangeName(CurrencyAccountName name)
    {
        var oldName = Name;

        Name = name;
        
        RaiseDomainEvent(new CurrencyAccountNameChangedDomainEvent(oldName, name, this));
    }
    
    /// <summary>
    /// Adds an income transaction to the account, validating its uniqueness and date.
    /// </summary>
    /// <param name="income">The income transaction to add.</param>
    /// <exception cref="IncomeAlreadyExistException">Thrown if the income already exists.</exception>
    /// <exception cref="TransactionDateLaterThanExpectedException">Thrown if the income date is later than expected.</exception>
    public void AddIncome(Income income)
    {
        if (Incomes.Any(i => i == income))
        {
            throw new IncomeAlreadyExistException(income);
        }
        
        if (income.Date.Day > DateTime.Today.Day)
        {
            throw new TransactionDateLaterThanExpectedException(income);
        }
        
        ProcessTransaction(income);
        
        Incomes.Add(income);
        
        RaiseDomainEvent(new IncomeAddedDomainEvent(income, this));
    }
    
    /// <summary>
    /// Adds a payment transaction to the account, validating its uniqueness and date.
    /// </summary>
    /// <param name="payment">The payment transaction to add.</param>
    /// <exception cref="PaymentAlreadyExistException">Thrown if the payment already exists.</exception>
    /// <exception cref="TransactionDateLaterThanExpectedException">Thrown if the payment date is later than expected.</exception>
    public void AddPayment(Payment payment)
    {
        if (Payments.Any(p => p == payment))
        {
            throw new PaymentAlreadyExistException(payment);
        }
        
        if (payment.Date.Day > DateTime.Today.Day)
        {
            throw new TransactionDateLaterThanExpectedException(payment);
        }
        
        ProcessTransaction(payment);
        
        Payments.Add(payment);
        
        RaiseDomainEvent(new PaymentAddedDomainEvent(payment, this));
    }

    /// <summary>
    /// Removes an income transaction from the account.
    /// </summary>
    /// <param name="transaction">The income transaction to remove.</param>
    /// <exception cref="IncomeNotFoundException">Thrown if the income is not found.</exception>
    public void RemoveIncome(Transaction transaction)
    {
        var income = Incomes.FirstOrDefault(i => i == transaction);

        if (income is null)
        {
            throw new IncomeNotFoundException(transaction);
        }
        
        RollbackTransaction(income);
        
        Incomes.Remove(income);
        
        RaiseDomainEvent(new IncomeRemovedDomainEvent(income, this));
    }
    
    /// <summary>
    /// Removes a payment transaction from the account.
    /// </summary>
    /// <param name="transaction">The payment transaction to remove.</param>
    /// <exception cref="PaymentNotFoundException">Thrown if the payment is not found.</exception>
    public void RemovePayment(Transaction transaction)
    {
        var payment = Payments.FirstOrDefault(i => i == transaction);

        if (payment is null)
        {
            throw new PaymentNotFoundException(transaction);
        }
        
        RollbackTransaction(payment);
        
        Payments.Remove(payment);
        
        RaiseDomainEvent(new PaymentRemovedDomainEvent(payment, this));
    }
    
    /// <summary>
    /// Adds a recurring monthly income entry to the account, ensuring no duplicate entries.
    /// </summary>
    /// <param name="monthlyIncome">The monthly income to add.</param>
    /// <exception cref="MonthlyIncomeAlreadyExistException">Thrown if the monthly income already exists.</exception>
    public void AddMonthlyIncome(MonthlyIncome monthlyIncome)
    {
        if (MonthlyIncomeExist(monthlyIncome.Name))
        {
            throw new MonthlyIncomeAlreadyExistException(monthlyIncome.Name);
        }
        
        MonthlyIncomes.Add(monthlyIncome);
        
        RaiseDomainEvent(new MonthlyIncomeAddedDomainEvent(monthlyIncome, this));
    }

    /// <summary>
    /// Edits an existing monthly income entry.
    /// </summary>
    /// <param name="oldName">The current name of the monthly income.</param>
    /// <param name="newName">The new name for the monthly income.</param>
    /// <param name="amount">The new amount for the monthly income.</param>
    /// <param name="currency">The new currency for the monthly income.</param>
    /// <exception cref="MonthlyIncomeAlreadyExistException">Thrown if a monthly income with the new name already exists.</exception>
    public void EditMonthlyIncome(TransactionName oldName, TransactionName newName, Amount amount)
    {
        var monthlyIncome = GetMonthlyIncome(oldName);

        if (oldName != newName)
        {
            if (MonthlyIncomeExist(newName))
            {
                throw new MonthlyIncomeAlreadyExistException(monthlyIncome.Name);
            }
            
            monthlyIncome.Name = newName;
            
            RaiseDomainEvent(new MonthlyIncomeNameEditedDomainEvent(oldName, newName,  this));
        }

        if (amount != monthlyIncome.Amount)
        {
            
            var oldAmount = monthlyIncome.Amount;
            monthlyIncome.Amount = amount;
            
            RaiseDomainEvent(new MonthlyIncomeAmountEditedDomainEvent(monthlyIncome.Name, oldAmount, amount, this));
        }
    }
    
    // public void EditMonthlyIncomeName(TransactionName oldName, TransactionName newName)
    // {
    //     var monthlyIncome = GetMonthlyIncome(oldName);
    //
    //     if (MonthlyIncomeExist(newName))
    //     {
    //         throw new MonthlyIncomeAlreadyExistException(monthlyIncome.Name);
    //     }
    //     
    //     monthlyIncome.Name = newName;
    //     
    //     RaiseDomainEvent(new MonthlyIncomeNameEditedDomainEvent(oldName, newName,  this));
    //
    // }
    //
    // public void EditMonthlyIncomeAmount(TransactionName name, Amount amount)
    // {
    //     var monthlyIncome = GetMonthlyIncome(name);
    //     
    //     var oldAmount = monthlyIncome.Amount;
    //     monthlyIncome.Amount = amount;
    //     
    //     RaiseDomainEvent(new MonthlyIncomeAmountEditedDomainEvent(name, oldAmount, amount, this));
    //
    // }
    
    /// <summary>
    /// Removes a monthly income entry from the account.
    /// </summary>
    /// <param name="name">The name of the monthly income to remove.</param>
    public void RemoveMonthlyIncome(TransactionName name)
    {
        var monthlyIncome = GetMonthlyIncome(name);
        
        MonthlyIncomes.Remove(monthlyIncome);
        
        RaiseDomainEvent(new MonthlyIncomeDeletedDomainEvent(monthlyIncome, this));
    }
        
    /// <summary>
    /// Adds a recurring monthly payment entry to the account, ensuring no duplicate entries.
    /// </summary>
    /// <param name="monthlyPayment">The monthly payment to add.</param>
    /// <exception cref="MonthlyPaymentAlreadyExistException">Thrown if the monthly payment already exists.</exception>
    public void AddMonthlyPayment(MonthlyPayment monthlyPayment)
    {
        if (MonthlyPaymentExist(monthlyPayment.Name))
        {
            throw new MonthlyPaymentAlreadyExistException(monthlyPayment.Name);
        }
        
        MonthlyPayments.Add(monthlyPayment);
        
        RaiseDomainEvent(new MonthlyPaymentAddedDomainEvent(monthlyPayment, this));
    }

    /// <summary>
    /// Edits an existing monthly payment entry.
    /// </summary>
    /// <param name="oldName">The current name of the monthly payment.</param>
    /// <param name="newName">The new name for the monthly payment.</param>
    /// <param name="amount">The new amount for the monthly payment.</param>
    /// <param name="currency">The new currency for the monthly payment.</param>
    /// <param name="categoryName">The new category name for the monthly payment.</param>
    /// <exception cref="MonthlyPaymentAlreadyExistException">Thrown if a monthly payment with the new name already exists.</exception>
    public void EditMonthlyPayment(TransactionName oldName, TransactionName newName, Amount amount, Category category)
    {
        var monthlyPayment = GetMonthlyPayment(oldName);

        if (newName != oldName)
        {
            if (MonthlyPaymentExist(newName))
            {
                throw new MonthlyPaymentAlreadyExistException(monthlyPayment.Name);
            }
           
            monthlyPayment.Name = newName;
            
            RaiseDomainEvent(new MonthlyPaymentNameEditedDomainEvent(oldName, newName, this));
        }

        if (amount != monthlyPayment.Amount)
        {
            var oldAmount = monthlyPayment.Amount;
            monthlyPayment.Amount = amount;
            
            RaiseDomainEvent(new MonthlyPaymentAmountEditedDomainEvent(monthlyPayment.Name, oldAmount, amount, this));
        }

        if (category != monthlyPayment.Category)
        {
            var oldCategory = monthlyPayment.Category;
            monthlyPayment.Category = category;
            
            RaiseDomainEvent(new MonthlyPaymentCategoryEditedDomainEvent(monthlyPayment.Name, oldCategory, category, this));
        }
    }
    
    // public void EditMonthlyPaymentName(TransactionName oldName, TransactionName newName, Amount amount, Category categoryName)
    // {
    //     var monthlyPayment = GetMonthlyPayment(oldName);
    //     
    //     if (MonthlyPaymentExist(newName))
    //     {
    //         throw new MonthlyPaymentAlreadyExistException(monthlyPayment.Name);
    //     }
    //     
    //     monthlyPayment.Name = newName;
    //     
    //     RaiseDomainEvent(new MonthlyPaymentNameEditedDomainEvent(oldName, newName,  this));
    // }
    //
    // public void EditMonthlyPaymentAmount(TransactionName name, Amount amount)
    // {
    //     var monthlyPayment = GetMonthlyPayment(name);
    //     
    //     var oldAmount = monthlyPayment.Amount;
    //     monthlyPayment.Amount = amount;
    //     
    //     RaiseDomainEvent(new MonthlyPaymentAmountEditedDomainEvent(name, oldAmount, amount, this));
    // }
    //
    // public void EditMonthlyPaymentCategory(TransactionName name, Category categoryName)
    // {
    //     var monthlyPayment = GetMonthlyPayment(name);
    //
    //     var oldCategoryName = monthlyPayment.Category;
    //     monthlyPayment.Category = categoryName;
    //     
    //     RaiseDomainEvent(new MonthlyPaymentCategoryEditedDomainEvent(name, oldCategoryName, categoryName , this));
    // }

    /// <summary>
    /// Removes a monthly payment entry from the account.
    /// </summary>
    /// <param name="name">The name of the monthly payment to remove.</param>
    public void RemoveMonthlyPayment(TransactionName name)
    {
        var monthlyPayment = GetMonthlyPayment(name);
        
        MonthlyPayments.Remove(monthlyPayment);
        
        RaiseDomainEvent(new MonthlyPaymentDeletedDomainEvent(monthlyPayment, this));
    }
    
    /// <summary>
    /// Accepts a monthly income entry by converting it into a regular income transaction.
    /// </summary>
    /// <param name="monthlyIncome">The monthly income to accept.</param>
    public void AcceptMonthlyIncome(TransactionName name, Amount amount)
    {

        var monthlyIncome = GetMonthlyIncome(name);

        if (amount != monthlyIncome.Amount)
        {
            EditMonthlyIncome(monthlyIncome.Name, monthlyIncome.Name, amount);
        }
        
        var income = new Income(monthlyIncome.Name, monthlyIncome.Month.Date, monthlyIncome.Currency, monthlyIncome.Amount);

        MonthlyIncomes.Remove(monthlyIncome);
        
        AddIncome(income);

        var newMonthlyIncome = new MonthlyIncome(
            monthlyIncome.Name, 
            monthlyIncome.Month.NextMonth(),
            monthlyIncome.Currency, 
            monthlyIncome.Amount);
        
        AddMonthlyIncome(newMonthlyIncome);
        
        RaiseDomainEvent(new MonthlyIncomeAcceptedDomainEvent(monthlyIncome, income, this));
    }
    
    /// <summary>
    /// Accepts a monthly payment entry by converting it into a regular payment transaction.
    /// </summary>
    /// <param name="monthlyPayment">The monthly payment to accept.</param>
    public void AcceptMonthlyPayment(TransactionName name, Amount amount)
    {
        var monthlyPayment = GetMonthlyPayment(name);

        if (amount != monthlyPayment.Amount)
        {
            EditMonthlyPayment(monthlyPayment.Name, monthlyPayment.Name, amount, monthlyPayment.Category);
        }
        
        var payment = new Payment(monthlyPayment.Name, monthlyPayment.Month.Date, monthlyPayment.Currency, monthlyPayment.Amount, monthlyPayment.Category);
        
        MonthlyPayments.Remove(monthlyPayment);
        
        AddPayment(payment);

        var newMonthlyPaymment = new MonthlyPayment(
            monthlyPayment.Name, 
            monthlyPayment.Month.NextMonth(),
            monthlyPayment.Currency, 
            monthlyPayment.Amount,
            monthlyPayment.Category);
        
        AddMonthlyPayment(newMonthlyPaymment);
        
        RaiseDomainEvent(new MonthlyPaymentAcceptedDomainEvent(monthlyPayment, payment, this));
    }

    public void ConvertCurrencyTo(Currency from, Currency to, decimal amount, decimal coefficient)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException(amount);
        }

        var income = new Income(new TransactionName("Currency conversion"), DateTime.UtcNow, to, new Amount(amount));

        var convertedAmount = new Amount(amount / coefficient);

        var payment = new Payment(new TransactionName("Currency Conversion"), DateTime.UtcNow, from, convertedAmount,
            Category.Entertainment);


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
    }
    
    public void CreateBudget(Budget budget)
    {
        if (Budget is null)
        {
            Budget = budget;
        
            RaiseDomainEvent(new BudgetCreatedDomainEvent(null, Budget, this));

            return;
        }
        
        if (Budget.Date.Date.Month == DateTime.UtcNow.Month)
        {
            throw new BudgetAlreadyExistException(Budget.Date.Date);
        }
        
        var oldBudget = Budget;

        Budget = budget;
        
        RaiseDomainEvent(new BudgetCreatedDomainEvent(oldBudget, Budget, this));

    }

    public void ChangeBudgetName(BudgetName name)
    {
        if (Budget is null)
        {
            throw new BudgetNotFoundException();
        }
        
        var oldName = Budget.Name;

        Budget.ChangeName(name);
        
        RaiseDomainEvent(new BudgetNameChangedDomainEvent(oldName, name, this));
    }

    public void AddExpense(Expense newExpense)
    {
        if (Budget is null)
        {
            throw new BudgetNotFoundException();
        }

        if (Budget.Expenses.Exists(e => e == newExpense))
        {
            throw new ExpenseAlreadyExistException(newExpense.Category);
        }
        
        Budget.AddExpense(newExpense);
        
        RaiseDomainEvent(new ExpenseAddedDomainEvent(newExpense, this));
    }
    
    public void EditExpense(Category category, ExpenseAmount newExpenseAmount)
    {
        if (Budget is null)
        {
            throw new BudgetNotFoundException();
        }
        
        var expense = Budget.Expenses.FirstOrDefault(e => e.Category == category);

        if (expense is null)
        {
            throw new ExpenseNotFoundException(category);
        }
        
        var oldAmount = expense.Amount;
        
        expense.ChangeAmount(category, newExpenseAmount);
        
        RaiseDomainEvent(new ExpenseEditedDomainEvent(expense, oldAmount, this));
    }
    
    public void RemoveExpense(Category category)
    {
        if (Budget is null)
        {
            throw new BudgetNotFoundException();
        }
  
        var expense = Budget.Expenses.FirstOrDefault(e => e.Category == category);

        if (expense is null)
        {
            throw new ExpenseNotFoundException(category);
        }

        Budget.RemoveExpense(expense);
        
        RaiseDomainEvent(new ExpenseDeletedDomainEvent(category, this));
    }
    
    public void DeleteBudget()
    {

        if (Budget is null)
        {
            throw new BudgetNotFoundException();
        }
        
        var budget = Budget;
        
        Budget = null;
        
        RaiseDomainEvent(new BudgetDeletedDomainEvent(budget, this));
    }
    // co z powiadomieniami
}