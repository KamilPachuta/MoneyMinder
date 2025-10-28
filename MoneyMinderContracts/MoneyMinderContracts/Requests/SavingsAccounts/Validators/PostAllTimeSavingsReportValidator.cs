using FluentValidation;

namespace MoneyMinderContracts.Requests.SavingsAccounts.Validators;

public class PostAllTimeSavingsReportValidator : AbstractValidator<PostAllTimeSavingsReportRequest>
{
    public PostAllTimeSavingsReportValidator()
    {
        RuleFor(x => x.SavingsAccountIds)
            .NotNull()
            .Must(x => x.Any());
    }
}