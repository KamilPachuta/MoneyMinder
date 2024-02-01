using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetBalances(Guid Id) : IRequest<IEnumerable<BalanceModel>>;