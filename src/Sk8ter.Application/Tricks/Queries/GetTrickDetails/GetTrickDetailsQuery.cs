using MediatR;

namespace Sk8ter.Application.Tricks.Queries.GetTrickDetails;

public class GetTrickDetailsQuery : IRequest<TrickDetailsVm>
{
    public int Id { get; set; }
}
