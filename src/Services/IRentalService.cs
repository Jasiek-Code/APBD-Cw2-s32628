using projekt_obiektowy.Domain;

namespace projekt_obiektowy.Services;

public interface IRentalService
{
    void Rent(User user, Hardware hardware);
    void Return(Hardware hardware);
}