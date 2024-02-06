using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication20.Entities;

public class GenreEntityMap : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).IsRequired();
        builder.HasMany(_ => _.Books).WithOne(_ => _.Genre)
            .HasForeignKey(_ => _.GenreId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}