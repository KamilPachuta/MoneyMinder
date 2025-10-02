using FluentValidation;

namespace MoneyMinderContracts.Requests.Accounts.Validators;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(50);
        
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
        
        RuleFor(x => x.PhoneCode)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(4);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(11);

        RuleFor(x => x.BirthDate)
            .NotNull()
            .Must(BeAdult)
            .WithMessage("You must be an adult to proceed.");

        RuleFor(x => x.GenderDto)
            .IsInEnum();

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

    private bool BeAdult(DateTime? birthDate)
    {
        if (birthDate is null)
        {
            return false;
        }
        
        var today = DateTime.Today;
        var age = today.Year - birthDate.Value.Year;

        if (birthDate.Value.Date > today.AddYears(-age))
        {
            age--;
        }

        return age >= 18;
    }
}