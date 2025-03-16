namespace emergen_see_backend.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }
        
        // Relationships
        public int QueueId { get; set; } // Foreign key
        public Queue Queue { get; set; } // Navigation property

        public int? AssignedDoctorId { get; set; } // Nullable foreign key
        public Doctor? AssignedDoctor { get; set; } // Navigation property

        public TriageForm? TriageForm { get; set; } // Navigation property
    }
}
