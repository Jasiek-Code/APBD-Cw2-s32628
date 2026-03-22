namespace projekt_obiektowy.Domain;

public abstract class User(string name, string surname)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; } = name;
    public string Surname { get; } = surname;

    public abstract int MaxRentals { get; }
}