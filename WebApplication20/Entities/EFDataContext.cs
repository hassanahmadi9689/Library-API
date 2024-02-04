using Microsoft.EntityFrameworkCore;

namespace WebApplication20.Entities;

public class EFDataContext : DbContext
{
    public DbSet<Book>? Book { get; set; }
    public DbSet<Author>? Author { get; set; }
    public DbSet<Genre>? Genre { get; set; }
    public DbSet<User>? User { get; set; }
    public DbSet<RentBook> RentBook { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    
    
    {
        optionsBuilder.UseSqlServer("Server=.;Database=Library7;\n" +
                                    "Trusted_Connection=true;TrustServerCertificate=yes");
    
    }
    
}