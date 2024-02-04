namespace WebApplication20.Entities;

public class RentBook
{
    public int Id { get; set; }
    public bool IsBack { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    
}