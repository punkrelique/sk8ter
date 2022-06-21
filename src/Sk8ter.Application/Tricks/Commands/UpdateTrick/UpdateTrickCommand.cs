using MediatR;
using Sk8ter.Domain.Entities;
using Sk8ter.Domain.Enums;

namespace Sk8ter.Application.Tricks.Commands.UpdateTrick;

public class UpdateTrickCommand : IRequest<Trick>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Difficulty Difficulty { get; set; }
}