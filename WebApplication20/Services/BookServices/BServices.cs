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

    public void DeleteBook(int id)
    {
        var book = _context.Book.FirstOrDefault(_ => _.Id == id);
        if (book is null)
        {
            throw new Exception("book not found");
        }

        _context.Book.Remove(book);
    }

    public void UpdateBook(int id, UpdateBookDto dto)
    {
        var book = _context.Book.FirstOrDefault(_ => _.Id == id);
        if (book is null)
        {
            throw new Exception("Book Not Found ");
        }

        book.Id = book.Id;
        book.Name = dto.Name;
       
        book.Count = dto.Count;
        book.Publication = dto.YearPublication;

        _context.SaveChanges();
    }


    public List<GetBooksDto> GetAllBooks(GetBooksDto dto)
    {
        var book = _context.Book.Select(_ => new GetBooksDto()
        {
            Name = _.Name,
            Count = _.Count,
            YearPublication = _.Publication

        }).ToList();
        return book;
    }

    public List<GetBooksDto> GetSearchBook(
        GetBookFilterDto getBookFilterDto)
    {
        var books = _context.Book.Select(_ => new GetBooksDto()
        {
            Name = _.Name,
            YearPublication = _.Publication,
            Count = _.Count

        }).ToList();


       var findBook= books.Where(_ => _.Name.Contains(getBookFilterDto.Name)).ToList();
       if (findBook is null)
       {
           throw new Exception("not found");
       }

       return findBook;

    }
    
}