namespace NTierArchitecture.Presentation.API.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }

        public int ClassID { get; set; }

        public string? ClassName { get; set; }
    }
}
