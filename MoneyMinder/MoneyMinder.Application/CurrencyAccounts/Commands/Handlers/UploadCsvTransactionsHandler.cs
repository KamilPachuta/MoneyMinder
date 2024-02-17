using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class UploadCsvTransactionsHandler : CurrencyCommandHandler<UploadCsvTransactionsCommand>
{
    public UploadCsvTransactionsHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override Task Handle(UploadCsvTransactionsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}