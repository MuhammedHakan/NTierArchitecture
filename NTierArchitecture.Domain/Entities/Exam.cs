namespace NTierArchitecture.Domain.Entities;

public class Exam : BaseEntity
{
    public int LessonID { get; set; }
    public int StudentID { get; set; }
    public DateTime ExamDate { get; set; }
    public int Duration { get; set; }
    public bool IsSecondary { get; set; }
    public float Note { get; set; }
    public Student? Student { get; set; }

    public Lesson? Lesson { get; set; }
}
