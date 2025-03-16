using emergen_see_backend.Enums;

namespace emergen_see_backend.Models
{
    public class TriageForm
    {
        public int Id { get; set; }
        public virtual required Nurse Nurse { get; set; }
        public int NurseId { get; set; }
        public virtual required Patient Patient { get; set; }
        public int PatientId { get; set; }
        public virtual required Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public required string Symptoms { get; set; }
        public required string Diagnosis { get; set; }
        public TriageStatus Status { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}
