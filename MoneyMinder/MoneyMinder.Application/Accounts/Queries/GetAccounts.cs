using MediatR;
using MoneyMinder.Domain.Accounts;

namespace MoneyMinder.Application.Accounts.Queries;

public class GetAccounts : IRequest<IEnumerable<Account>>;