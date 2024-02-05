using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountMonthPayments(Guid Id) : IRequest<IEnumerable<TransactionModel>>;