using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetAll : IRequest<IEnumerable<CurrencyAccountModel>>;