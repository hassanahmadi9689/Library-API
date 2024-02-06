using WebApplication20.Entities;

namespace WebApplication20.Services.GenreServices;

public class GServices
{
     private EfDataContext _dataContext = new EfDataContext();

     public void AddGenre(AddGenreDto dto)
     {
          var genre = new Genre
          {
               Name = dto.Name
          };
          _dataContext.Genre.Add(genre);
          _dataContext.SaveChanges();
     }

}