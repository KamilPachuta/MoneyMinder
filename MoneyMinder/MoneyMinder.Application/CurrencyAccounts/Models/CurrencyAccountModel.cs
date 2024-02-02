namespace MoneyMinder.Application.CurrencyAccounts.Models;

public record CurrencyAccountModel(
    Guid Id,
    string Name, 
    BudgetModel Budget, 
    IEnumerable<BalanceModel> Balances, 
    IEnumerable<IncomeModel> Incomes, 
    IEnumerable<PaymentModel> Payments, 
    IEnumerable<MonthlyIncomeModel> MonthlyIncomes, 
    IEnumerable<MonthlyPaymentModel> MonthlyPayments);