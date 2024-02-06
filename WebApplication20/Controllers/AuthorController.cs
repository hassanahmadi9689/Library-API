using Microsoft.AspNetCore.Mvc;
using WebApplication20.Services.AuthorServices;
using WebApplication20.Services.AuthorServices.Dto;

namespace WebApplication20.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private Aservices _aservices = new Aservices();

    [HttpPost("Add-Author")]
    public void AddBook(AddAuthorDto dto)
    {
        _aservices.AddAuthor(dto);
    }
    [HttpDelete("Delete-Author/{Id}")]
    public void DeleteUser([FromRoute] int Id)
    {
        _aservices.DeleteAuthor(Id);
    }
}