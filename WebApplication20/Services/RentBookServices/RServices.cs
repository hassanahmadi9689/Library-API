using Microsoft.EntityFrameworkCore;
using WebApplication20.Entities;
using WebApplication20.Services.RentBookServices.Dto;

namespace WebApplication20.Services.RentBookServices;

public class RServices
{
    private readonly EfDataContext _dataContext = new EfDataContext();

    public void AddRentBook(AddRentDto dto)
    {
        var book =
            _dataContext.Book!.FirstOrDefault(_ => _.Id == dto.BookId);
        if (book is null)
        {
            throw new Exception("Book Not Found  ");
        }


        var user =
            _dataContext.User!.FirstOrDefault(_ => _.Id == dto.UserId);
        if (user is null)
        {
            throw new Exception("User Not Found");
        }

        var count =
            _dataContext.RentBook!.Count(_ =>
                _.UserId == dto.UserId && _.IsBack == false);
        if (count == 4)
        {
            throw new Exception("user cant rent book moore than 4 times");
        }

        if (book.Count == 0)
        {
            throw new Exception("book not available...");
        }

        var rentBook = new RentBook
        {
            IsBack = false,
            BookId = dto.BookId,
            UserId = dto.UserId
        };
        _dataContext.RentBook!.Add(rentBook);
        book.Count--;
        _dataContext.SaveChanges();
    }

    public void ReturnBook(ReturnBookDto dto)
    {
        var rentBook = _dataContext.RentBook!.FirstOrDefault(_ =>
            _.UserId == dto.UserId && _.BookId == dto.BookId);
        if (rentBook is null)
        {
            throw new Exception("Book or user not found");
        }

        rentBook.IsBack = true;
        var book =
            _dataContext.Book!.FirstOrDefault(_ => _.Id == dto.BookId);
        book!.Count++;
        _dataContext.SaveChanges();
    }

    public List<GetAllRentBookDto> GetAllRentBook(
        GetAllRentBookDto getBookFilterDto)
    {
        var rentBooks = _dataContext.RentBook!
            .Include(u => u.User)
            .Include(b => b.Book)
            .Select(_ =>
                new GetAllRentBookDto()
                {
                    UserName = _.User!.Name,
                    BookName = _.Book!.Name
                }).ToList();
        return rentBooks;
    }

    public List<GetAllRentBookDto> GetRentBookFilter(
        GetRentBookFilterDto dto)
    {
        var rentBooks = _dataContext.RentBook!
            .Include(u => u.User)
            .Include(b => b.Book)
            .Select(_ =>
                new GetAllRentBookDto()
                {
                    UserName = _.User!.Name,
                    BookName = _.Book!.Name
                }).ToList();


        var books = rentBooks
            .Where(_ => _.UserName==dto.UserName)
            .ToList();
        if (books is null)
        {
            throw new Exception("Book not found");
        }

        return books;
    }
}