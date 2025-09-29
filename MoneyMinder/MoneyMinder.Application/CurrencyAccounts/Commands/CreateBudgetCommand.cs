using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record CreateBudgetCommand(
    Guid AccountId, 
    Guid CurrencyAccountId,
    DateTime Date, 
    Currency Currency, 
    IEnumerable<LimitWriteModel> Limits) 
    : CurrencyCommand(AccountId, CurrencyAccountId);