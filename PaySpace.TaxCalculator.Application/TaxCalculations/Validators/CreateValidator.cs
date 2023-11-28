using FluentValidation;

namespace PaySpace.TaxCalculator.Application
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        //RuleFor(v => v.Title)
        //    .MaximumLength(200)
        //    .NotEmpty();
    }
}
