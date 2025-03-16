namespace emergen_see_backend.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Patient>? Patients { get; set; }
        public ICollection<TriageForm>? TriageForms { get; set; }
    }
}
