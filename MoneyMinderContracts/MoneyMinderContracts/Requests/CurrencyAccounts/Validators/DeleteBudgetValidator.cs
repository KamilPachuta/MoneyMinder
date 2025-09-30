using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;

public class DeleteBudgetValidator : AbstractValidator<DeleteBudgetRequest>
{
    public DeleteBudgetValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();
    }
}