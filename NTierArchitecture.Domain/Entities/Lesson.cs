namespace NTierArchitecture.Domain.Entities;

public class Lesson : BaseEntity
{
    public string? Name { get; set; }
    public int WeeklyHour { get; set; }

    public ICollection<Exam>? Exams { get; set; }
    public ICollection<Teacher>? Teachers { get; set; }
}
