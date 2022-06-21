using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sk8ter.Application.Interfaces;

namespace Sk8ter.Application.Tricks.Queries.GetAllTricks;

public class GetTrickListQueryHandler : IRequestHandler<GetTrickListQuery, TrickListVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTrickListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<TrickListVm> Handle(GetTrickListQuery request, CancellationToken cancellationToken)
    {
        var tricks = await _context.Tricks
            .ProjectTo<TrickLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new TrickListVm { Tricks = tricks };
    }
}