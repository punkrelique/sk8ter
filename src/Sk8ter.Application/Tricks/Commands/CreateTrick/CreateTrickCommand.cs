using MediatR;
using Sk8ter.Domain.Entities;
using Sk8ter.Domain.Enums;

namespace Sk8ter.Application.Tricks.Commands.CreateTrick;

public class CreateTrickCommand : IRequest<Trick>
{
    public string Name { get; set; }
    public Difficulty Difficulty { get; set; }
}