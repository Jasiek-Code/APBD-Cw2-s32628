namespace projekt_obiektowy;

public interface IRentalService
{
    void RentHardware(User user, Hardware hardware);
    void ReturnHardware(Hardware hardware);
}