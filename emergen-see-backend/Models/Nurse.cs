namespace emergen_see_backend.Models
{
    public class Nurse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<TriageForm>? TriageForms {get; set; }
    }
}
