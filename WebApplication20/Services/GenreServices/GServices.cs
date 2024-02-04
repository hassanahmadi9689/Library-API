using WebApplication20.Entities;

namespace WebApplication20.Services.GenreServices;

public class GServices
{
     private EFDataContext _dataContext = new EFDataContext();

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