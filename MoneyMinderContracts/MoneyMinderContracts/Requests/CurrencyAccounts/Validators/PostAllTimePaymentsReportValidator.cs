using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;

public class PostAllTimePaymentsReportValidator: AbstractValidator<PostAllTimePaymentsReportRequest>
{
    public PostAllTimePaymentsReportValidator()
    {
        RuleFor(x => x.CurrencyAccountIds)
            .NotNull()
            .Must(i => i.Any());

        RuleFor(x => x.Currencies)
            .NotNull()
            .Must(c => c.Any());
    }
}