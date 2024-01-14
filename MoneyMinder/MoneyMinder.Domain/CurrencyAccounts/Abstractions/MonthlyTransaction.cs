using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public abstract record MonthlyTransaction
{
    
    public MonthlyTransactionName Name { get; }
    public Month Date { get; }
    public Currency Currency { get; }
    public decimal Amount { get; }
    

    protected MonthlyTransaction(MonthlyTransactionName name, Month date, Currency currency, decimal amount)
    {
        CheckAmount(amount);
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
    }
    protected abstract void CheckAmount(decimal amount);

    public override string ToString()
    {
        return $"TransactionName: '{Name.Name}'\nTransactionDate: '{Date}'\nCurrency: '{Currency}'\nAmount: '{Amount}'\n";
    }
    
}