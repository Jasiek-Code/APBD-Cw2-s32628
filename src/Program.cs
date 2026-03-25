using projekt_obiektowy.Repositories;
using projekt_obiektowy.Services;
using projekt_obiektowy.UI;


ConsoleMenu.Run(new RentalService(new JsonRentalRepository()));