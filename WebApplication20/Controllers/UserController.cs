using Microsoft.AspNetCore.Mvc;
using WebApplication20.Services.UserServices;
using WebApplication20.Services.UserServices.Dto;

namespace WebApplication20.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UServices _uServices = new UServices();
    [HttpPost("Add-User")]
    public void AddUser(AddUserDto dto)
    {
        _uServices.AddUser(dto);
    }

    [HttpDelete("Delete-user/{Id}")]
    public void DeleteUser([FromRoute] int Id)
    {
        _uServices.DeleteUser(Id);
    }
    
    [HttpPatch("Update-User{id}")]
    public void UpdateUser([FromRoute] int id,
        [FromBody] UpdateUserDto dto)
    {
        _uServices.UpdateBook(id,dto);
    }
}