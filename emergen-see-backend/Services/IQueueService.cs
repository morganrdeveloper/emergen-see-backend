using emergen_see_backend.Models;

namespace emergen_see_backend.Services
{
    public interface IQueueService
    {
        Task<IEnumerable<Queue>> GetAllQueuesAsync();
        Task<Queue> GetQueueByIdAsync(int id);
        Task<Queue> CreateQueueAsync(Queue queue);
        Task<Queue> UpdateQueueAsync(int id, Queue queue);
        Task DeleteQueueAsync(int id);
    }
}
