using System.Text.Json;
using projekt_obiektowy.Domain;

namespace projekt_obiektowy.Repositories;

public class JsonRentalRepository(string filePath = "Data/rentals.json") : IRentalRepository
{
    public void Save(IEnumerable<Rental> rentals)
    {
        Directory.CreateDirectory("Data"); 
        
        var options = new JsonSerializerOptions { WriteIndented = true };
        
        var jsonString = JsonSerializer.Serialize(rentals, options);
        
        File.WriteAllText(filePath, jsonString);
    }

    public IEnumerable<Rental> Load()
    {
        if (!File.Exists(filePath)) return [];
        
        var jsonString = File.ReadAllText(filePath);
        
        if (string.IsNullOrWhiteSpace(jsonString)) return [];

        var loadedRentals = JsonSerializer.Deserialize<IEnumerable<Rental>>(jsonString);
        
        return loadedRentals ?? [];
    }
}