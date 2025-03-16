namespace emergen_see_backend.DTOs
{
    public class TriageFormDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; } // Foreign key for Patient
        public int DoctorId { get; set; } // Foreign key for Doctor
        public string Symptoms { get; set; }
        public int Severity { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
