using projekt_obiektowy.Domain;
namespace projekt_obiektowy.Repositories;

public interface IRentalRepository
{
    void Save(IEnumerable<Rental> rentals);
    IEnumerable<Rental> Load();
}