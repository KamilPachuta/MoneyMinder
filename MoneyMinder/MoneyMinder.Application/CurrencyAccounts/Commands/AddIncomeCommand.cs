using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record AddIncomeCommand(
    Guid AccountId, 
    Guid CurrencyAccountId, 
    string Name, 
    DateTime Date, 
    Currency Currency, 
    decimal Amount) 
    : CurrencyCommand(AccountId, CurrencyAccountId);