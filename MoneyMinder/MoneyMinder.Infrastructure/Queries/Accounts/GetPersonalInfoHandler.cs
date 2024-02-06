using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Models;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.Accounts;

internal sealed class GetPersonalInfoHandler : IRequestHandler<GetPersonalInfo, PersonalInfoModel>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetPersonalInfoHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PersonalInfoModel> Handle(GetPersonalInfo request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Accounts
            .Include(a => a.User)
            .ThenInclude(u => u.Address)
            .Where(a => a.Id == request.Id)
            .Select(a => new PersonalInfoModel(a.Email, a.User.Name, a.User.PhoneNumber, a.User.BirthDate,
                a.User.Gender, a.User.Address.Country, a.User.Address.City, a.User.Address.PostalCode,
                a.User.Address.Street))
            .FirstOrDefaultAsync();
            //.FirstOrDefaultAsync(a => a.Id == request.Id);

        return result;


    }
}