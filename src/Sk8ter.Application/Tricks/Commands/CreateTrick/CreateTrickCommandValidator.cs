using FluentValidation;
using Sk8ter.Application.Tricks.Commands.UpdateTrick;

namespace Sk8ter.Application.Tricks.Commands.CreateTrick;

public class CreateTrickCommandValidator : AbstractValidator<CreateTrickCommand>
{
    public CreateTrickCommandValidator()
    {
        RuleFor(trick => trick.Name).NotEmpty().MaximumLength(200).MinimumLength(2);
    }
}