using projekt_obiektowy.Domain;

namespace projekt_obiektowy.Services;

public class RentalService : IRentalService
{
    private readonly List<Rental> _activeRentals = [];

    public void Rent(User user, Hardware hardware)
    {
        
    }

    public void Return(Hardware hardware)
    {
        
    }
}