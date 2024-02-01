using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record Get(Guid Id) : IRequest<CurrencyAccountModel>;