using MediatR;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccountsMetadataQuery(Guid AccountId) : IRequest<GetCurrencyAccountsMetadataResponse>;
