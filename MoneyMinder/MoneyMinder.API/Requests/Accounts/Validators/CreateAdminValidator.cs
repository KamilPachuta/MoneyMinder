using FluentValidation;

namespace MoneyMinder.API.Requests.Accounts.Validators;

public sealed class CreateAdminValidator : AbstractValidator<CreateAdminRequest>
{
    public CreateAdminValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(50);
    }
}