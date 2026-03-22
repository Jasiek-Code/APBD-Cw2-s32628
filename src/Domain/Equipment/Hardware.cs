using System.Text.Json.Serialization;

namespace projekt_obiektowy.Domain.Equipment;

[JsonDerivedType(typeof(Laptop), typeDiscriminator: "laptop")]
[JsonDerivedType(typeof(Projector), typeDiscriminator: "projector")]
[JsonDerivedType(typeof(Camera), typeDiscriminator: "camera")]

public abstract class Hardware(string name)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = name;

    public bool IsAvailable { get; set; } = true;
}