namespace NTierArchitecture.Domain.Entities;

public class Class : BaseEntity
{
    public string? Name { get; set; }
    public int Capacity { get; set; }

    public ICollection<Student>? Students { get; set; }
}
