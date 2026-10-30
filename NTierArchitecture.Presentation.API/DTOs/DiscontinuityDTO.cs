namespace NTierArchitecture.Presentation.API.DTOs
{
    public class DiscontinuityDTO
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public DateTime DateofDiscontinuity { get; set; }
        public int Days { get; set; }
        public bool Excuse { get; set; }

        public string? StudentName { get; set; }
    }
}
