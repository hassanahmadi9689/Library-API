using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication20.Entities;

public class UserEntityMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).IsRequired();
        builder.HasMany(_ => _.UserRentBooks).WithOne(_ => _.User)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}