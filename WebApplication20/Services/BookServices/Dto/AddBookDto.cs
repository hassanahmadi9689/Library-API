namespace WebApplication20.Services.BookServices.Dto;

public class AddBookDto
{
    public string Name { get; set; }
    public string YearPublication { get; set; }
    public int Count { get; set; }
    
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
}
