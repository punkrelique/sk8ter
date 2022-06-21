using MediatR;
using Microsoft.EntityFrameworkCore;
using Sk8ter.Application.Common.Exceptions;
using Sk8ter.Application.Interfaces;
using Sk8ter.Domain.Entities;

namespace Sk8ter.Application.Tricks.Commands.UpdateTrick;

public class UpdateCommandHandler : IRequestHandler<UpdateTrickCommand, Trick>
{
    private readonly IApplicationDbContext _context;

    public UpdateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Trick> Handle(UpdateTrickCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tricks
            .FirstOrDefaultAsync(trick => trick.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Trick), request.Id);
        }

        entity.Name = request.Name;
        entity.Difficulty = request.Difficulty;

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}