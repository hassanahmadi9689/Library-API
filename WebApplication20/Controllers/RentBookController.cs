using Microsoft.AspNetCore.Mvc;
using WebApplication20.Services.RentBookServices;
using WebApplication20.Services.RentBookServices.Dto;

namespace WebApplication20.Controllers;
[ApiController]
[Route("[controller]")]
public class RentBookController : ControllerBase
{
    private RServices _rServices = new RServices();

    [HttpPost("Rent_Book")]
    public void Add(AddRentDto dto)
    {
        _rServices.AddRentBook(dto);
        
    }

    [HttpPatch("Return-Book")]
    public int ReturnBook([FromQuery]ReturnBookDto dto)
    {
        
        _rServices.ReturnBook(dto);
        return dto.BookId;
    }
    [HttpGet("get-all-rent-books")]
    public List<GetAllRentBookDto> GetRentBooks([FromQuery] GetAllRentBookDto dto)
    {
        return _rServices.RentBooks(dto);
    }
    [HttpGet("get-by-search-user-Name")]
    public List<GetAllRentBookDto> GetBook([FromQuery] GetFilterRentBookDto getBookFilterDto)
    {
        return _rServices.GetBySearchUser(getBookFilterDto);
    }
    
}