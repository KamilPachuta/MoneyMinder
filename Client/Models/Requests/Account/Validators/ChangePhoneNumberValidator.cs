using Client.Models.Requests.Account.Commands;
using FluentValidation;

namespace Client.Models.Requests.Account.Validators;

public sealed class ChangePhoneNumberValidator : AbstractValidator<ChangePhoneNumberRequest>
{
    public ChangePhoneNumberValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(4);

        RuleFor(x => x.Number)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(11);
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ChangePhoneNumberRequest>.CreateWithOptions((ChangePhoneNumberRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}