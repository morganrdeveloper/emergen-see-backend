namespace emergen_see_backend.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int QueueId { get; set; }
        public int TriageFormId { get; set; }
        public int? AssignedDoctorId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }
    }
}
