using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication20.Entities;

public class AuthorEntityMap : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).IsRequired();
        builder.HasMany(_ => _.Books).WithOne(_ => _.Author)
            .HasForeignKey(_ => _.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}