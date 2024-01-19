using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Users.ValueObjects;

Console.WriteLine("Hello, World!");

CurrencyAccount currencyAccount = new (new Guid(), new CurrencyAccountName("aaaaaaaaaaaaa"));


Income income = new Income(new TransactionName("income1"), DateTime.Today, new Currency.PLN(), new Amount(5000));
Income income2 = new Income(new TransactionName("income2"), DateTime.Today, new Currency.PLN(), new Amount(780));
Payment payment = new Payment(new TransactionName("payment"), DateTime.Today, new Currency.PLN(), new Amount(-150), new CategoryName("groceries"));
Payment payment2 = new Payment(new TransactionName("payment"), DateTime.Today, new Currency.PLN(), new Amount(-100), new CategoryName("groceries"));
Payment payment3 = new Payment(new TransactionName("payment"), DateTime.Today, new Currency.PLN(), new Amount(-50), new CategoryName("groceries"));
Payment payment4 = new Payment(new TransactionName("payment"), DateTime.Today, new Currency.PLN(), new Amount(-1200), new CategoryName("groceries"));




currencyAccount.AddIncome(income);
var balance = currencyAccount.Balances.FirstOrDefault(b => b.Currency == income.Currency);
Console.WriteLine($"Currency: '{balance.Currency}'\nAmount: '{balance.Amount}'\n");

currencyAccount.AddIncome(income2);
Console.WriteLine($"Currency: '{balance.Currency}'\nAmount: '{balance.Amount}'\n");

currencyAccount.RemoveIncome(income2);
Console.WriteLine($"Currency: '{balance.Currency}'\nAmount: '{balance.Amount}'\n");

currencyAccount.AddPayment(payment);
Console.WriteLine($"Currency: '{balance.Currency}'\nAmount: '{balance.Amount}'\n");

currencyAccount.AddPayment(payment2);
Console.WriteLine($"Currency: '{balance.Currency}'\nAmount: '{balance.Amount}'\n");

currencyAccount.AddPayment(payment3);
Console.WriteLine($"Currency: '{balance.Currency}'\nAmount: '{balance.Amount}'\n");

currencyAccount.AddPayment(payment4);
Console.WriteLine($"Currency: '{balance.Currency}'\nAmount: '{balance.Amount}'\n");

currencyAccount.RemovePayment(payment);
Console.WriteLine($"Currency: '{balance.Currency}'\nAmount: '{balance.Amount}'\n");










