using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountMonthIncomes(Guid Id) : IRequest<IEnumerable<TransactionModel>>;