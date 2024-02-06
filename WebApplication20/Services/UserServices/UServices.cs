using WebApplication20.Entities;
using WebApplication20.Services.UserServices.Dto;

namespace WebApplication20.Services.UserServices;

public class UServices
{
    private EfDataContext _dataContext = new EfDataContext();

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