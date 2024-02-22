using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;


public sealed class UploadCsvTransactionsValidator : AbstractValidator<UploadCsvTransactionsRequest>
{
    public UploadCsvTransactionsValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();

        RuleFor(x => x.File)
            .NotEmpty();
    }
}