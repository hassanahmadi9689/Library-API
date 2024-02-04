using WebApplication20.Entities;
using WebApplication20.Services.UserServices.Dto;

namespace WebApplication20.Services.UserServices;

public class UServices
{
    private EFDataContext _dataContext = new EFDataContext();

    public void AddUser(AddUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name
        };
        _dataContext.User.Add(user);
        _dataContext.SaveChanges();
    }
}