using MediatR;
using MoneyMinder.Domain.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccount(Guid id) : IRequest<CurrencyAccount>;