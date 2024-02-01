using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetMonthlyTransactions(Guid Id) : IRequest<IEnumerable<MonthlyTransactionModel>>;