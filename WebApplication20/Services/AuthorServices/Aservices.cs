using WebApplication20.Entities;
using WebApplication20.Services.AuthorServices.Dto;

namespace WebApplication20.Services.AuthorServices;

public class Aservices
{
    private readonly EfDataContext _context = new EfDataContext();

    public void AddAuthor(AddAuthorDto dto)
    {
        var author = new Author
        {
            Name = dto.Name
        };
        _context.Author!.Add(author);
        _context.SaveChanges();
    }

    public void DeleteAuthor(int id)
    {
        var author = _context.Author!.FirstOrDefault(_ => _.Id == id);
        if (author is null)
        {
            throw new Exception("User not found...");
        }

        _context.Author!.Remove(author);
        _context.SaveChanges();
    }
}