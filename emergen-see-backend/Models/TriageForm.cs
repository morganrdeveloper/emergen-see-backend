using emergen_see_backend.Enums;

namespace emergen_see_backend.Models
{
    public class TriageForm
    {
        public int Id { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public Enums.TriageStatus Status { get; set; }
        public DateTime RecordedDate { get; set; }

        // Relationships
        public int NurseId { get; set; } // Foreign key
        public Nurse Nurse { get; set; } // Navigation property

        public int DoctorId { get; set; } // Foreign key
        public Doctor Doctor { get; set; } // Navigation property

        public int PatientId { get; set; } // Foreign key
        public Patient Patient { get; set; } // Navigation property
    }
}
