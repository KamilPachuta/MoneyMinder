using MediatR;
using MoneyMinder.Domain.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccounts : IRequest<IEnumerable<CurrencyAccount>>;