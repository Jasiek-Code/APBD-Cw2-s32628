namespace projekt_obiektowy.Domain;

public class Rental(User user, Hardware hardware)
{
    public required User User { get; init; }
    public required Hardware Hardware { get; init; }
    
    public DateTime RentDate { get; init; } = DateTime.Now;
    public DateTime DueDate { get; init; }
    public DateTime? ReturnDate { get; init; } = null;
}