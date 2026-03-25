using projekt_obiektowy.Domain;
using projekt_obiektowy.Domain.Equipment;
using projekt_obiektowy.Domain.Users;
using projekt_obiektowy.Repositories;

namespace projekt_obiektowy.Services;

public class RentalService(IRentalRepository repository) : IRentalService
{
    private readonly List<Rental> _rentals = repository.Load().ToList();
    
    public IReadOnlyList<Rental> Rentals => _rentals.AsReadOnly();
    
    private void SaveData()
    {
        repository.Save(_rentals);
    }
    
    public void Rent(User user, Hardware hardware, int daysToRent)
    {
        var activeRentalsForUser = _rentals.Count(
            rental => rental.User.Equals(user) 
                      && rental.ReturnDate == null);

        if (activeRentalsForUser >= user.MaxRentals)
        {
            throw new Exception($"Rental limit for {user.Name} {user.Surname} reached.");
        }

        if (!hardware.IsAvailable)
        {
            throw new Exception($"Hardware {hardware.Name} is not available.");
        }
        
        hardware.IsAvailable = false;
        _rentals.Add(new Rental(user, hardware, daysToRent));
        
        SaveData();
    }

    public void Return(Guid hardwareId, DateTime? returnDate = null)
    {
        var userRental = _rentals.FirstOrDefault(
            rental => rental.Hardware.Id == hardwareId 
                      && rental.ReturnDate == null);

        if (userRental is null)
        {
            throw new Exception($"No active rental found for hardware ID {hardwareId}.");
        }
        
        var actualReturnDate = returnDate ?? DateTime.Now;
        
        userRental.CalculateAndSetPenalty(actualReturnDate);
        
        userRental.ReturnDate = actualReturnDate;
        userRental.Hardware.IsAvailable = true;
        
        SaveData();
    }
}