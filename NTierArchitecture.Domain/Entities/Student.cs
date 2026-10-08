namespace NTierArchitecture.Domain.Entities;
public class Student : BaseEntity
{
    public string? Name { get; set; }
    public bool Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Phone { get; set; }

    public Class? Class { get; set; }

    public int ClassID { get; set; }

    public ICollection<Discontinuity>? Discontinuties { get; set; }
    public ICollection<Exam>? Exams { get; set; }

}
