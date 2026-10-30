namespace NTierArchitecture.Presentation.API.DTOs
{
    public class ExamDTO
    {
        public int ID { get; set; }
        public int LessonID { get; set; }
        public int StudentID { get; set; }
        public DateTime ExamDate { get; set; }
        public int Duration { get; set; }
        public bool IsSecondary { get; set; }
        public float Note { get; set; }

        public string? StudentName { get; set; }
        public string? LessonName { get; set; }
    }
}
