using emergen_see_backend.Data;
using emergen_see_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace emergen_see_backend.Services
{
    public class QueueService : IQueueService
    {
        private readonly ApplicationDbContext _context;

        public QueueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Queue>> GetAllQueuesAsync()
        {
            return await _context.Queues.ToListAsync();
        }

        public async Task<Queue> GetQueueByIdAsync(int id)
        {
            return await _context.Queues.FindAsync(id);
        }

        public async Task<Queue> CreateQueueAsync(Queue queue)
        {
            _context.Queues.Add(queue);
            await _context.SaveChangesAsync();
            return queue;
        }

        public async Task<Queue> UpdateQueueAsync(int id, Queue queue)
        {
            _context.Entry(queue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return queue;
        }

        public async Task DeleteQueueAsync(int id)
        {
            var queue = await _context.Queues.FindAsync(id);
            if (queue != null)
            {
                _context.Queues.Remove(queue);
                await _context.SaveChangesAsync();
            }
        }
    }
}
