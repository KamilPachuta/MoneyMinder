using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetTransactions(Guid Id) : IRequest<IEnumerable<TransactionModel>>;
