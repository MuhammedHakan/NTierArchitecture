namespace NTierArchitecture.Domain.Entities;

public class Teacher : BaseEntity
{
    public string? Name { get; set; }
    public bool Branch { get; set; }
    public string? Phone { get; set; }
    public int LessonID { get; set; }

    public Lesson? Lesson { get; set; }
}