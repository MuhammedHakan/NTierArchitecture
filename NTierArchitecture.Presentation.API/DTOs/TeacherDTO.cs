namespace NTierArchitecture.Presentation.API.DTOs
{
    public class TeacherDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public bool Branch { get; set; }
        public string? Phone { get; set; }

        public int LessonID { get; set; }

        public string? LessonName { get; set; }
    }
}
