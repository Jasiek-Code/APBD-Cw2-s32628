namespace projekt_obiektowy;

public abstract class User(string name, string surname)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
}