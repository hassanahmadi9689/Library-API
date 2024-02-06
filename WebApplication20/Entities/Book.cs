using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication20.Entities;

public class Book
{
    
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Publication { get; set; }
    public int Count { get; set; }
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }
    public int? GenreId { get; set; }
    public Genre? Genre { get; set; }
    public HashSet<RentBook> RentBook { get; set; }
    
}