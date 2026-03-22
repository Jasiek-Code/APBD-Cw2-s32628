namespace projekt_obiektowy.Domain;

public abstract class Hardware(string name)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = name;

    public bool IsAvailable { get; set; } = true;
}

public class Laptop(string name, string processor, int ramGb) : Hardware(name)
{
    public string Processor { get; set; } = processor;
    public int RamGb { get; set; } = ramGb;
}

public class Projector(string name, int brightness, string resolution) : Hardware(name)
{
    public int Brightness { get; set; } = brightness;
    public string Resolution { get; set; } = resolution;
}

public class Camera(string name, bool isDigital, int memoryGb) : Hardware(name)
{
    public bool IsDigital { get; set; } = isDigital;
    public int MemoryGb { get; set; } = memoryGb;
}