using MediatR;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Infrastructure.Queries;

public class GetAccountHandler : IRequestHandler<GetAccount, Account>
{
    private readonly IAccountRepository _repository;

    public GetAccountHandler(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Account> Handle(GetAccount request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync(request.Id);

        return result;

    }
}