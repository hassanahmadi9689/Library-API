using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication20.Entities;

public class BookEntityMap : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).IsRequired();
        
        builder.HasOne(_ => _.Author).WithMany(_ => _.Books)
            .HasForeignKey(_ => _.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(_ => _.Genre).WithMany(_ => _.Books)
            .HasForeignKey(_ => _.GenreId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(_ => _.RentBook).WithOne(_ => _.Book)
            .HasForeignKey(_ => _.BookId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}