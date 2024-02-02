using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class DeleteCurrencyAccountValidator : AbstractValidator<DeleteCurrencyAccountRequest>
{
    public DeleteCurrencyAccountValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}