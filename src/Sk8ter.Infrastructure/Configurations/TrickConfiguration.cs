using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sk8ter.Domain.Entities;
using Sk8ter.Domain.Enums;

namespace Sk8ter.Infrastructure.Configurations;

public class TrickConfiguration : IEntityTypeConfiguration<Trick>
{
    public void Configure(EntityTypeBuilder<Trick> builder)
    {
        builder.HasKey(trick => trick.Id);
        builder.
            Property(trick => trick.Id)
            .ValueGeneratedOnAdd();
        builder.HasIndex(trick => trick.Id).IsUnique();
        builder
            .Property(trick => trick.Difficulty)
            .HasConversion(e => e.ToString(), c => Enum.Parse<Difficulty>(c));
    }
}