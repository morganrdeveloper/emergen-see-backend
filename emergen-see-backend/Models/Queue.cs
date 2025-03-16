using emergen_see_backend.Enums;

namespace emergen_see_backend.Models
{
    public class Queue
    {
        public int Id { get; set; }
        public ICollection<Patient>? Patients { get; set; }
        public QueueType QueueType { get; set; }
    }
}
