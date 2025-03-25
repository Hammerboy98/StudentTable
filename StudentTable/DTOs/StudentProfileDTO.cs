namespace StudentTable.DTOs
{
    public class StudentProfileRequestDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FiscalCode { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int StudentId { get; set; }
    }

    public class StudentProfileResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FiscalCode { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
