using Microsoft.AspNetCore.Mvc;
using WebApplication20.Services.RentBookServices;
using WebApplication20.Services.RentBookServices.Dto;

namespace WebApplication20.Controllers;
[ApiController]
[Route("[controller]")]
public class RentBookController : ControllerBase
{
    private Rservices _rservices = new Rservices();

    [HttpPost("Rent_Book")]
    public void Add(AddRentDto dto)
    {
        _rservices.AddRentBook(dto);
        
    }

    [HttpPatch]
    public int ReturnBook([FromQuery]ReturnBookDto dto)
    {
        
        _rservices.ReturnBook(dto);
        return dto.BookId;
    }
}