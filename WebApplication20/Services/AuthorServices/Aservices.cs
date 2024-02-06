using WebApplication20.Entities;
using WebApplication20.Services.AuthorServices.Dto;

namespace WebApplication20.Services.AuthorServices;

public class Aservices
{
    private EfDataContext _context = new EfDataContext();

    public void AddAuthor(AddAuthorDto dto)
    {
        var author = new Author
        {
            Name = dto.Name
        };
        _context.Author.Add(author);
        _context.SaveChanges();
    }
}