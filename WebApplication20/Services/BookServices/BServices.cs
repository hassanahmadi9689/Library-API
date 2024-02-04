using WebApplication20.Entities;
using WebApplication20.Services.BookServices.Dto;

namespace WebApplication20.Services.BookServices;

public class BServices
{
    private EFDataContext _context = new EFDataContext();

    public void AddBook(AddBookDto dto)
    {
        var book = new Book
        {
            GenreId = null,
            AuthorId = null,
            Name = dto.Name,
            Count = dto.Count,
            Publication = dto.YearPublication
        };
        _context.Book.Add(book);
        _context.SaveChanges();
    }

    public void AddAuthorToBook(AddAuthorToBookDto dto)
    {
        var book = _context.Book.FirstOrDefault(_ => _.Id == dto.BookId);
        if (book is null)
        {
            throw new Exception("Book Not Found");
        }

        var Author =
            _context.Author.FirstOrDefault(_ => _.Id == dto.AuthorId);
        if (Author is null)
        {
            throw new Exception("Author not found ");
        }

        book.AuthorId = Author.Id;
        _context.Book.Update(book);
        _context.SaveChanges();
    }
    public void AddGenreToBook(AddGenreToBook dto)
    {
        var book = _context.Book.FirstOrDefault(_ => _.Id == dto.BookId);
        if (book is null)
        {
            throw new Exception("Book Not Found");
        }

        var Genre =
            _context.Author.FirstOrDefault(_ => _.Id == dto.GenreId);
        if (Genre is null)
        {
            throw new Exception("Author not found ");
        }

        book.GenreId = Genre.Id;
        _context.Book.Update(book);
        _context.SaveChanges();
    }
}