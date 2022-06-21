using Microsoft.EntityFrameworkCore;
using Sk8ter.Application.Interfaces;
using Sk8ter.Domain.Entities;
using Sk8ter.Infrastructure.Configurations;

namespace Sk8ter.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Trick> Tricks { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TrickConfiguration()); 
        base.OnModelCreating(builder);
    }
}