using emergen_see_backend.DTOs;
using emergen_see_backend.Models;

namespace emergen_see_backend.Services
{
    public interface IQueueService
    {
        Task<IEnumerable<QueueDto>> GetAllQueuesAsync();
        Task<QueueDto> GetQueueByIdAsync(int id);
        Task<QueueDto> CreateQueueAsync(QueueDto queueDto);
        Task<QueueDto> UpdateQueueAsync(int id, QueueDto queueDto);
        Task DeleteQueueAsync(int id);
    }
}
