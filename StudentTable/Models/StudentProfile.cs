namespace StudentTable.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FiscalCode { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        // Relazione con Student
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}
