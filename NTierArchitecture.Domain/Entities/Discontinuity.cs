namespace NTierArchitecture.Domain.Entities;

public class Discontinuity : BaseEntity
{
    public int StudentID { get; set; }
    public DateTime DateofDiscontinuity { get; set; }
    public int Days { get; set; }
    public bool Excuse { get; set; }

    public Student? Student { get; set; }
}