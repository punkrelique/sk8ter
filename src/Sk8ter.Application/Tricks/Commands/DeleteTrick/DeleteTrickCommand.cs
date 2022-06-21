using MediatR;

namespace Sk8ter.Application.Tricks.Commands.DeleteTrick;

public class DeleteTrickCommand : IRequest
{
    public int Id { get; set; }
}