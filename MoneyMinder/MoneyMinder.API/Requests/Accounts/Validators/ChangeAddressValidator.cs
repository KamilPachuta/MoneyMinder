using FluentValidation;

namespace MoneyMinder.API.Requests.Accounts.Validators;

public sealed class ChangeAddressValidator : AbstractValidator<ChangeAddressRequest>
{
    public ChangeAddressValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);
        
        RuleFor(x => x.City)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
        
        RuleFor(x => x.Street)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);
            
    }
}