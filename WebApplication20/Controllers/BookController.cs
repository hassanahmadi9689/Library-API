using Microsoft.AspNetCore.Mvc;
using WebApplication20.Services.BookServices;
using WebApplication20.Services.BookServices.Dto;

namespace WebApplication20.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private BServices Services = new BServices();

    [HttpPost("Add-Book")]
    public void AddBook(AddBookDto dto)
    {
        Services.AddBook(dto);
    }

    [HttpPatch("Set-Book-Author")]
    public void SetAuthorBook(AddAuthorToBookDto dto)
    {
        Services.AddAuthorToBook(dto);
    }
    
    [HttpPatch("Set-Book-Genre")]
    public void SetGenreBook(AddGenreToBook dto)
    {
        Services.AddGenreToBook(dto);
    }
}