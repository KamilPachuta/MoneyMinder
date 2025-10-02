using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinder.Infrastructure.Exceptions;
using MoneyMinderContracts.Responses.Accounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.Accounts;

internal class GetUserNameHandler : IRequestHandler<GetUserNameQuery, GetUserNameResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetUserNameHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetUserNameResponse> Handle(GetUserNameQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Accounts
            .Include(a => a.User)
            .Where(a => a.Id == request.AccountId)
            .Select(a => a.User!.Name)
            .FirstOrDefaultAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(result))
        {
            throw new AccountNotFoundException(request.AccountId);
        }
        
        return new GetUserNameResponse(result);
    }
}