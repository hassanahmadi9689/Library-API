using Microsoft.AspNetCore.Mvc;
using WebApplication20.Services.GenreServices;

namespace WebApplication20.Controllers;
[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private GServices _gServices = new GServices();
    [HttpPost("Add-Genre")]
    public void AddGenre(AddGenreDto dto)
    {
        _gServices.AddGenre(dto);
    }
    [HttpDelete("Delete-Genre/{Id}")]
    public void DeleteUser([FromRoute] int Id)
    {
        _gServices.DeleteGenre(Id);
    }
}