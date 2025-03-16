namespace emergen_see_backend.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int>? PatientIds { get; set; } // Optional: List of patient IDs assigned to the doctor
        public ICollection<int>? TriageFormIds { get; set; } // Optional: List of triage form IDs associated with the doctor
    }
}
