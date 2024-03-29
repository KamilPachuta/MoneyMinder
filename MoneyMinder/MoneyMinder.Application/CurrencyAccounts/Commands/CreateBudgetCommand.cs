using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.WriteModels;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record CreateBudgetCommand(
    Guid AccountId, 
    Guid CurrencyAccountId, 
    string Name, 
    decimal ExpectedIncome, 
    IEnumerable<ExpenseWriteModel> Expenses,
    DateTime Date, 
    Currency Currency) 
    : CurrencyCommand(AccountId, CurrencyAccountId);