using MediatR;
using Microsoft.EntityFrameworkCore;
using Sk8ter.Application.Common.Exceptions;
using Sk8ter.Application.Interfaces;
using Sk8ter.Domain.Entities;

namespace Sk8ter.Application.Tricks.Commands.DeleteTrick;

public class DeleteTrickCommandHandler : IRequestHandler<DeleteTrickCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTrickCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(DeleteTrickCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tricks
            .FirstOrDefaultAsync(trick => trick.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Trick), request.Id);
        }

        _context.Tricks.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}