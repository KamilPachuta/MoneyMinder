using Client.Models.Enums;
using Client.Models.Requests.Account.Commands;
using FluentValidation;
using MoneyMinder.API.Requests.Accounts;

namespace Client.Models.Requests.Account.Validators;

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
            .Must(BeAdult)
            .WithMessage("You must be an adult to proceed.");
     
        RuleFor(x=> x.Gender)
            .Must(value => Enum.IsDefined(typeof(Gender), value))
            .WithMessage("Invalid value for the Gender field.");

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
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateUserRequest>.CreateWithOptions((CreateUserRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}