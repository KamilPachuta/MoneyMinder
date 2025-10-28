using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;

public class PostAllTimeBalanceReportValidator : AbstractValidator<PostAllTimeBalanceReportRequest>
{
    public PostAllTimeBalanceReportValidator()
    {
        RuleFor(x => x.CurrencyAccountIds)
            .NotNull()
            .Must(i => i.Any());
        
        RuleFor(x => x.Currencies)
            .NotNull()
            .Must(c => c.Any());
    }
}