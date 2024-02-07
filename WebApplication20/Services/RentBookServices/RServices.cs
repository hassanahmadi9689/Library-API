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

    public List<GetAllRentBookDto> RentBooks(GetAllRentBookDto dto)
    {
        var rentBook = _dataContext.RentBook!.Select(_ =>
            new GetAllRentBookDto()
            {
                BookId = _.BookId,
                UserId = _.UserId
            }).ToList();
        if (rentBook is null)
        {
            throw new Exception("list is empty ...");
        }

        return rentBook;
    }

    public List<GetAllRentBookDto> GetBySearchUser(
        GetFilterRentBookDto getBookFilterDto)
    {
        var rentBooks = _dataContext.RentBook!.Select(_ =>
            new GetAllRentBookDto()
            {
                UserId = _.UserId,
                BookId = _.BookId
            }).ToList();
        var user =
            _dataContext.User!.SingleOrDefault(_ =>
                _.Name == getBookFilterDto.Name);
        if (user is null)
        {
            throw new Exception("user not found");
        }

        var rentBook = rentBooks.Where(_ => _.UserId == user.Id).ToList();
        return rentBook;
    }
}