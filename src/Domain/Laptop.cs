namespace projekt_obiektowy.Domain;

public class Laptop(string name, string processor, int ramGb) : Hardware(name)
{
    public string Processor { get; set; } = processor;
    public int RamGb { get; set; } = ramGb;
}