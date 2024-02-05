using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetActualExpensesFromCurrentMonth(Guid Id) : IRequest<IEnumerable<PaymentModel>>;