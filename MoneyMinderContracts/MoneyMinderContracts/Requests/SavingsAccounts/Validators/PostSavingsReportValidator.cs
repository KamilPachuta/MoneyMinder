using FluentValidation;

namespace MoneyMinderContracts.Requests.SavingsAccounts.Validators;

public class PostSavingsReportValidator : AbstractValidator<PostSavingsReportRequest>
{
    public PostSavingsReportValidator()
    {
        RuleFor(x => x.SavingsAccountIds)
            .NotNull()
            .Must(x => x.Any());
      
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