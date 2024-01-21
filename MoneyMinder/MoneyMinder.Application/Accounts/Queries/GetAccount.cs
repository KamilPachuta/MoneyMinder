using MediatR;
using MoneyMinder.Domain.Accounts;

namespace MoneyMinder.Application.Accounts.Queries;

public record GetAccount(Guid Id) : IRequest<Account>
{
    
}