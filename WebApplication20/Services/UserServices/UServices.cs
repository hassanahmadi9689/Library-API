using WebApplication20.Entities;
using WebApplication20.Services.UserServices.Dto;

namespace WebApplication20.Services.UserServices;

public class UServices
{
    private readonly EfDataContext _dataContext = new EfDataContext();

    public void AddUser(AddUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name
        };
        _dataContext.User!.Add(user);
        _dataContext.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var user = _dataContext.User!.FirstOrDefault(_ => _.Id == id);
        if (user is null)
        {
            throw new Exception("User not found...");
        }

        _dataContext.User!.Remove(user);
        _dataContext.SaveChanges();
    }
}