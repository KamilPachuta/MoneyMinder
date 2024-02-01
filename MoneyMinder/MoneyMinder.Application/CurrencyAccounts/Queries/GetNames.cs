using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetNames(Guid Id) : IRequest<IEnumerable<CurrencyAccountNameModel>>;