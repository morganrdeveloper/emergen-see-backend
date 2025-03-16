using emergen_see_backend.Enums;

namespace emergen_see_backend.DTOs
{
    public class QueueDto
    {
        public int Id { get; set; }
        public QueueType QueueType { get; set; }
        public ICollection<int>? PatientIds { get; set; } // Optional: List of patient IDs in the queue
    }
}
