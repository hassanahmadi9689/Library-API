using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication20.Entities;

public class RentBookEntityMap : IEntityTypeConfiguration<RentBook>
{
    public void Configure(EntityTypeBuilder<RentBook> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.HasOne(_ => _.Book).WithMany(_ => _.RentBook)
            .HasForeignKey(_ => _.BookId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(_ => _.User).WithMany(_ => _.UserRentBooks)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}