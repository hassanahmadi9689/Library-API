using WebApplication20.Entities;

namespace WebApplication20.Services.GenreServices;

public class GServices
{
     private readonly EfDataContext _dataContext = new EfDataContext();

     public void AddGenre(AddGenreDto dto)
     {
          var genre = new Genre
          {
               Name = dto.Name
          };
          _dataContext.Genre!.Add(genre);
          _dataContext.SaveChanges();
     }
     public void DeleteGenre(int id)
     {
          if (_dataContext.Genre != null)
          {
               var genre = _dataContext.Genre.FirstOrDefault(_ => _.Id == id);
               if (genre is null)
               {
                    throw new Exception("User not found...");
               }

               _dataContext.Genre.Remove(genre);
               _dataContext.SaveChanges();
          }
          else
          {
               throw new Exception("List Is empty ...");
          }

         
     }


}