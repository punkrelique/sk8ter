using MediatR;
using Sk8ter.Application.Interfaces;
using Sk8ter.Domain.Entities;

namespace Sk8ter.Application.Tricks.Commands.CreateTrick;

public class CreateTrickCommandHandler : IRequestHandler<CreateTrickCommand, Trick>
{
    private readonly IApplicationDbContext _context;

    public CreateTrickCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Trick> Handle(CreateTrickCommand request, CancellationToken cancellationToken)
    {
        var trick = new Trick
        {
            Name = request.Name,
            Difficulty = request.Difficulty
        };

        await _context.Tricks.AddAsync(trick, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return trick;
    }
}