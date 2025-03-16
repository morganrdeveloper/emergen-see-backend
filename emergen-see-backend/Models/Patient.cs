namespace emergen_see_backend.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public required Queue Queue { get; set; }
        public int QueueId { get; set; }
        public virtual required TriageForm TriageForm { get; set; }
        public int TriageFormId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }
        public virtual Doctor? AssignedDoctor { get; set; }
        public int? AssignedDoctorId { get; set; }
    }
}
