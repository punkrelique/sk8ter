using Microsoft.EntityFrameworkCore;
using Sk8ter.Domain.Entities;

namespace Sk8ter.Application.Interfaces;

public interface IApplicationDbContext
{ 
    DbSet<Trick> Tricks { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}