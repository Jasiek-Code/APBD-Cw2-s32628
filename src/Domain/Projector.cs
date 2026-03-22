namespace projekt_obiektowy.Domain;

public class Projector(string name, int brightness, string resolution) : Hardware(name)
{
    public int Brightness { get; set; } = brightness;
    public string Resolution { get; set; } = resolution;
}