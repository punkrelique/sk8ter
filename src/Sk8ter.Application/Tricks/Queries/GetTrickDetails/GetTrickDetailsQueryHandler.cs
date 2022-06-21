using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sk8ter.Application.Common.Exceptions;
using Sk8ter.Application.Interfaces;
using Sk8ter.Domain.Entities;

namespace Sk8ter.Application.Tricks.Queries.GetTrickDetails;

public class GetTrickDetailsQueryHandler : IRequestHandler<GetTrickDetailsQuery, TrickDetailsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTrickDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<TrickDetailsVm> Handle(GetTrickDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tricks
            .FirstOrDefaultAsync(trick => trick.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Trick), request.Id);
        }

        return _mapper.Map<TrickDetailsVm>(entity);
    }
}