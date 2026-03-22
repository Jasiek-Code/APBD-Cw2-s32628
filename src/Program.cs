using projekt_obiektowy.Domain.Equipment;
using projekt_obiektowy.Domain.Users;
using projekt_obiektowy.Services;

Console.WriteLine("------Renting hardware project-------\n");
var rentalService = new RentalService();

// --- ADDING OBJECTS ---
var student = new Student("Jan", "Kowalski");
var employee = new Employee("Anna", "Nowak");

Console.WriteLine("* Added Users *\n");
Console.WriteLine($"Student added: {student.GetType().Name} {student.Name} {student.Surname}");
Console.WriteLine($"Employee added: {employee.GetType().Name} {employee.Name} {employee.Surname}\n");

var laptop = new Laptop("Dell XPS 15", "Intel i7", 16);
var camera = new Camera("Sony A7 III", true, 64);
var projector = new Projector("Epson 1080p", 3000, "1920x1080");

Console.WriteLine("* Added items *\n");
Console.WriteLine($"Laptop added: {laptop.GetType().Name} {laptop.Name}");
Console.WriteLine($"Camera added: {camera.GetType().Name} {camera.Name}");
Console.WriteLine($"Projector added: {projector.GetType().Name} {projector.Name}");

// --- RENTING ---
rentalService.Rent(student, laptop, 7);

Console.WriteLine("\n* Renting test #1 *\n");
Console.WriteLine("Rented items list:");
foreach (var rental in rentalService.Rentals.Where(r => r.ReturnDate == null))
{
    Console.WriteLine($"{rental.User.Name} rented {rental.Hardware.Name} for {rental.RentedForDays} days and has {Math.Round((rental.DueDate - DateTime.Now).TotalDays, 1)} days to return it.");
}

Console.WriteLine();

rentalService.Rent(student, projector, 14);
Console.WriteLine("* Renting test #2 *\n");
foreach (var rental in rentalService.Rentals.Where(r => r.ReturnDate == null))
{
    Console.WriteLine($"{rental.User.Name} rented {rental.Hardware.Name} for {rental.RentedForDays} days and has {Math.Round((rental.DueDate - DateTime.Now).TotalDays, 1)} days to return it.");
}

// --- RETURNING ON TIME ---
rentalService.Return(laptop, DateTime.Now);
Console.WriteLine("\n* Returning item test #1 (On Time) *\n");

foreach (var rental in rentalService.Rentals.Where(r => r.ReturnDate != null && r.Penalty == 0))
{
    Console.WriteLine($"[SUCCESS] {rental.User.Name} returned {rental.Hardware.Name} on time. Penalty: {rental.Penalty} PLN");
}

// --- RETURNING LATE ---
var simulatedLateDate = DateTime.Now.AddDays(30); 

rentalService.Return(projector, simulatedLateDate);
Console.WriteLine("\n* Returning item test #2 (Late) *\n");

foreach (var rental in rentalService.Rentals.Where(r => r.ReturnDate != null && r.Penalty > 0))
{
    Console.WriteLine($"[WARNING] {rental.User.Name} returned {rental.Hardware.Name} late! Penalty applied: {rental.Penalty} PLN");
}