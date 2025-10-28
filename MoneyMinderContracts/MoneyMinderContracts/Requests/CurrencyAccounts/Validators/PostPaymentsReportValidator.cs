using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;

public sealed class PostPaymentsReportValidator : AbstractValidator<PostPaymentsReportRequest>
{
    public PostPaymentsReportValidator()
    {
        RuleFor(x => x.CurrencyAccountIds)
            .NotNull()
            .Must(i => i.Any());

        RuleFor(x => x.Currencies)
            .NotNull()
            .Must(c => c.Any());

      
        RuleFor(x => x.From)
            .NotNull()
            .LessThanOrEqualTo(x => DateTime.UtcNow)
            .WithMessage("From date cannot be in the future.");

        RuleFor(x => x.To)
            .NotNull()
            .GreaterThan(x => x.From)
            .WithMessage("To date must be later than From date.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("To date cannot be in the future.");
       
    }
}