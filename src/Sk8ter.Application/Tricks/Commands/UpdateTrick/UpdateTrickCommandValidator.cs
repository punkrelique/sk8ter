using FluentValidation;

namespace Sk8ter.Application.Tricks.Commands.UpdateTrick;

public class UpdateTrickCommandValidator : AbstractValidator<UpdateTrickCommand>
{
    public UpdateTrickCommandValidator()
    {
        RuleFor(trick => trick.Id).NotEmpty().Must(id => id >= 0);
        RuleFor(trick => trick.Name).NotEmpty().MaximumLength(200);
    }
}