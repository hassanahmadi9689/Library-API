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

    [HttpDelete("delete-book/{id}")]
    public void DeleteBook([FromRoute] int id)
    {
        Services.DeleteBook(id);
    }

    [HttpPatch("Update-Book{id}")]
    public void UpdateBook([FromRoute] int id,
        [FromBody] UpdateBookDto dto)
    {
        Services.UpdateBook(id, dto);
    }

    [HttpGet("get-all-books")]
    public List<GetBooksDto> GetBooks([FromQuery]GetBooksDto dto)
    {
        return Services.GetAllBooks(dto);
    }

    [HttpGet("get-by-search")]
    public List<GetBooksDto> GetBook([FromQuery] GetBookFilterDto getBookFilterDto)
    {
        return Services.GetSearchBook(getBookFilterDto);
    }
}


