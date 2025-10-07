using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.Accounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.Accounts;


internal class GetUserDetailsHandler : IRequestHandler<GetUserDetailsQuery, GetUserDetailsResponse>
{
    private readonly MoneyMinderReadDbContext _context;


    public GetUserDetailsHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetUserDetailsResponse> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Accounts
            .Where(a => a.Id == request.AccountId)
            .Select(a => new
            {
                a.Email,
                a.User!.Name,
                a.User.PhoneNumber,
                a.User.BirthDate,
                a.User.Gender,
                a.User.Address.Country,
                a.User.Address.City,
                a.User.Address.PostalCode,
                a.User.Address.Street
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            throw new AccountNotFoundException(request.AccountId);
        }

        return new GetUserDetailsResponse(
            result.Email,
            result.Name,
            result.PhoneNumber,
            result.BirthDate,
            (GenderDto)result.Gender,
            result.Country,
            result.City,
            result.PostalCode,
            result.Street);
    }
}